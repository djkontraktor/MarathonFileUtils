namespace MarathonFileUtils.Sounds
{
    public class SoundSlot
    {
        public SoundId ID { get; private set; }
        public List<SoundPermutation> Samples { get; private set; }

        public SoundSlot(SoundId id, List<SoundPermutation> samples)
        {
            ID = id;
            Samples = samples;
        }
    }
}
