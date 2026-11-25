using MarathonFileUtils.Sounds.DataStructures;
using MarathonFileUtils.Sounds.SoundIds;

namespace MarathonFileUtils.Sounds.SoundsFiles
{
    public class RubiconSoundsFile : SoundsFile
    {
        public RubiconSoundsFile(string filePath)
        {
            List<SoundDefinition> definitions = Utils.OpenM2SoundFile(filePath, out string format);
            LoadSoundsFileBase(definitions, SoundIdLoader.RubiconSoundIds);
        }
    }
}
