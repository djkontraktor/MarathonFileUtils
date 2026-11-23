using MarathonFileUtils.Sounds.SoundIds;

namespace MarathonFileUtils.Sounds
{
    public class RubiconSoundsFile : SoundsFile
    {
        public RubiconSoundsFile(string filePath)
        {
            List<SoundDefinition> definitions = Utils.OpenM2SoundFile(filePath);
            LoadSoundsFileBase(definitions, SoundIdLoader.RubiconSoundIds);
        }
    }
}
