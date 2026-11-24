using MacFileUtils;

namespace MarathonFileUtils.Sounds.LowLevel
{
    public abstract class SoundsFileRaw : IDisposable
    {

        #region Abstract Members

        public abstract bool Open(MacFileSpecifier file);
        public abstract void Close();
        public abstract SoundDefinitionRaw GetSoundDefinition(int source, int soundIndex);
        public abstract SoundsFileHeader GetSoundHeader(SoundDefinitionRaw definition, int permutation);
        public abstract byte[] GetSoundData(SoundDefinitionRaw definition, int permutation);
        public abstract IEnumerable<int> GetSoundIndices(int source);

        #endregion

        #region Public Members

        public virtual int SourceCount
        {
            get
            {
                return 1;
            }
        }

        public string ResourceType
        {
            get
            {
                return TagToString(mTag);
            }
        }

        public void Dispose()
        {
            Close();
        }

        #endregion

        #region Private/Protected Properties

        protected uint mTag;

        #endregion

        #region Private/Protected Members

        private static string TagToString(uint tag)
        {
            char[] characters =
            {
                (char)((tag >> 24) & 0xFF),
                (char)((tag >> 16) & 0xFF),
                (char)((tag >> 8) & 0xFF),
                (char)(tag & 0xFF)
            };

            return new string(characters);
        }

        #endregion

    }
}
