namespace MarathonFileUtils.Sounds
{
    public class SoundId
    {
        public short Id { get; private set; }
        public int Index { get; private set; }
        public string Name { get; private set; }

        public SoundId(short id, int index, string name)
        {
            Id = id;
            Index = index;
            Name = name;
        }
    }
}
