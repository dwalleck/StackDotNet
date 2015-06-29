namespace StackDotNet.OpenStack.Models.ObjectStorage
{
    public class AccountMetadata
    {
        public int ObjectCount { get; set; }
        public int ContainerCount { get; set; }
        public int BytesUsed { get; set; }

        public AccountMetadata(int objectCount, int containerCount, int bytesUsed)
        {
            ObjectCount = objectCount;
            ContainerCount = containerCount;
            BytesUsed = bytesUsed;

        }
    }


}
