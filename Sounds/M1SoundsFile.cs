using MarathonFileUtils.Sounds.SoundIds;

namespace MarathonFileUtils.Sounds
{
    public class M1SoundsFile : SoundsFile
    {
        public M1SoundsFile(string filePath)
        {
            List<SoundDefinition> definitions = Utils.OpenM1SoundFile(filePath, out string format);
            LoadSoundsFileBase(definitions, SoundIdLoader.Marathon1SoundIds);
        }
    }
}
