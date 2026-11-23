namespace MarathonFileUtils.Sounds
{
    public class M2SoundsFile : SoundsFile
    {
        public M2SoundsFile(string filePath)
        {
            List<SoundDefinition> definitions = Utils.OpenM2SoundFile(filePath);
            LoadSoundsFileBase(definitions, M2SoundIds.IDs);
        }
    }
}
