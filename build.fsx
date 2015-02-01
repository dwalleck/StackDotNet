// include Fake lib
#r @"packages\FAKE\tools\FakeLib.dll"
open Fake
open System
open System.IO

RestorePackages()

// project name and description
let projectName = "StackDotNet"
let projectDescription = "A C# SDK for interacting with OpenStack clouds."
let projectSummary = projectDescription // TODO: write a summary
let version = "0.2.0"
let authors = ["Daryl Walleck"]

// directories
let buildDir = "./StackDotNet/bin"
let testResultsDir = "./testresults"
let packagingRoot = "./packaging/"
let packagingDir = packagingRoot @@ "StackDotNet"

let buildMode = getBuildParamOrDefault "buildMode" "Release"

let addAssembly (target : string) assembly =
    let includeFile force file =
        let file = file
        if File.Exists (Path.Combine("nuget", file)) then [(file, Some target, None)]
        elif force then raise <| new FileNotFoundException(file)
        else []

    seq {
        yield! includeFile true assembly
        yield! includeFile false <| Path.ChangeExtension(assembly, "pdb")
        yield! includeFile false <| Path.ChangeExtension(assembly, "xml")
        yield! includeFile false <| assembly + ".config"
    }

Target "Clean" (fun _ ->
    CleanDirs [buildDir; testResultsDir; packagingRoot; packagingDir;]
)

Target "BuildApp" (fun _ ->
    MSBuild null "Build" ["Configuration", buildMode] ["./StackDotNet.sln"]
    |> Log "AppBuild-Output: "
)

Target "UnitTests" (fun _ ->
    !! (sprintf "./Tests/bin/%s/**/Tests.dll" buildMode)
    |> xUnit (fun p -> 
            {p with 
                XmlOutput = true
                Verbose = false
                OutputDir = testResultsDir }))

Target "Default" DoNothing

Target "CreatePackage" (fun _ ->
    // Copy all the package files into a package folder
    CopyFiles packagingDir (Seq.singleton packagingRoot)
    NuGet (fun p -> 
        {p with
            Authors = authors
            Project = projectName
            Description = projectDescription                               
            OutputPath = packagingRoot
            Summary = projectSummary
            WorkingDir = packagingDir
            Version = version
            Dependencies = 
                [
                    ("Newtonsoft.Json", RequireExactly "6.0.6")
                    ("Microsoft.Net.Http", RequireExactly "2.2.28")
                    ("Microsoft.Bcl", RequireExactly "1.1.9")
                    ("Microsoft.Bcl.Build", RequireExactly "1.0.21")
                ]
            Files = 
                [
                    (@"..\..\StackDotNet\bin\Release\*.dll", Some "lib", None)
                ]
            Publish = false }) 
            "StackDotNet.nuspec"
)

"Clean"
   ==> "BuildApp"
   ==> "CreatePackage"
   ==> "Default"

RunTargetOrDefault "Default"
