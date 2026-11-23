using MarathonFileUtils.Sounds.SoundIds;

namespace MarathonFileUtils.Sounds
{
    public class M2SoundsFile : SoundsFile
    {
        public M2SoundsFile(string filePath)
        {
            List<SoundDefinition> definitions = Utils.OpenM2SoundFile(filePath);
            LoadSoundsFileBase(definitions, SoundIdLoader.Marathon2SoundIds);
        }
    }
}
