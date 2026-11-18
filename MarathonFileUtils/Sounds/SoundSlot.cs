using System.Collections.Generic;

namespace MarathonFileUtils.Sounds
{
    public class SoundSlot
    {
        public SoundId ID {  get; private set; }
        public List<SoundPermutation> Samples { get; private set; }

        public SoundSlot(SoundId iD, List<SoundPermutation> samples)
        {
            ID = iD;
            Samples = samples;
        }
    }
}
