using MarathonFileUtils.Sounds.SoundIds;

namespace MarathonFileUtils.Sounds
{
    public class M2SoundsFile : SoundsFile
    {
        public M2SoundsFile(string filePath, out SoundsFileFormat format)
        {
            List<SoundDefinition> definitions = Utils.OpenM2SoundFile(filePath, out string resId);

            List<SoundId> soundIds = new List<SoundId>();

            List<int> fileShape = GetShape(definitions);
            int shapeSum = fileShape.Sum();

            if (shapeSum == 583)
            {
                // Marathon Infinity sounds file
                soundIds = SoundIdLoader.Marathon2SoundIds;
                format = SoundsFileFormat.M2;
            }
            else if (shapeSum == 345)
            {
                // Rubicon sounds file
                soundIds = SoundIdLoader.RubiconSoundIds;
                format = SoundsFileFormat.Rubicon;
            }
            else
            {
                // Default to infinity
                soundIds = SoundIdLoader.Marathon2SoundIds;
                format = SoundsFileFormat.M2;
            }

            LoadSoundsFileBase(definitions, soundIds);
        }
    }
}
