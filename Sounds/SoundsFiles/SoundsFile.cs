using MarathonFileUtils.Sounds.DataStructures;

namespace MarathonFileUtils.Sounds.SoundsFiles
{
    public abstract class SoundsFile
    {
        public List<SoundSlot> SoundSlots = new List<SoundSlot>();

        public void LoadSoundsFileBase(List<SoundDefinition> definitions, List<SoundId> ids)
        {
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

                try
                {
                    SoundId soundId = ids.Where(i => i.Id == soundCode).First();
                    SoundSlot soundSlot = new SoundSlot(soundId, permutations);
                    SoundSlots.Add(soundSlot);
                }
                catch (Exception ex)
                {

                }
            }
        }

        protected List<int> GetShape(List<SoundDefinition> definitions)
        {
            List<int> permCount = new List<int>();

            foreach (SoundDefinition def in definitions)
            {
                permCount.Add(def.Permutations.Count);
            }

            return permCount;
        }

    }
}
