using System.Collections.Generic;
using System.Linq;

namespace MarathonFileUtils.Sounds
{
    public class M2SoundsFile : SoundsFile
    {
        public M2SoundsFile(string filePath)
        {
            List<SoundDefinition> definitions = Utils.OpenM2SoundFile(filePath);

            foreach (SoundDefinition def in definitions)
            {
                List<SoundPermutation> permutations = new List<SoundPermutation>();
                short soundCode = -1;

                foreach (SoundPermutation sound in def.Permutations)
                {
                    int bitsPerSample = sound.Header.BitsPerSample;
                    bool stereo = sound.Header.Stereo;
                    soundCode = sound.Definition.SoundCode;
                    int numSlots = def.Permutations.Count;
                    int slotNum = sound.Permutation + 1;
                    permutations.Add(sound);
                }

                SoundId soundId = M2SoundIds.IDs.Where(i => i.Id == soundCode).First();
                SoundSlot soundSlot = new SoundSlot(soundId, permutations);
                SoundSlots.Add(soundSlot);
            }
        }
    }
}
