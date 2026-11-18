using MarathonFileUtils.Sounds.LowLevel;
using System.Collections.Generic;

namespace MarathonFileUtils.Sounds
{
    public class SoundDefinition
    {
        public int Source { get; set; }
        public int SoundIndex { get; set; }
        public SoundDefinitionRaw Definition { get; set; }
        public List<SoundPermutation> Permutations { get; private set; }

        public SoundDefinition()
        {
            Permutations = new List<SoundPermutation>();
        }
    }
}
