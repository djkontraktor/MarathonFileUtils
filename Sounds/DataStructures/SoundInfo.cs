namespace MarathonFileUtils.Sounds.DataStructures
{
    public class SoundInfo
    {

        public int BitsPerSample { get; protected set; }
        public bool Stereo { get; protected set; }
        public bool LittleEndian { get; protected set; }
        public int BytesPerFrame { get; protected set; }
        public int LoopStart { get; protected set; }
        public int LoopEnd { get; protected set; }
        public uint Rate { get; protected set; }
        public int Length { get; protected set; }

        public SoundInfo()
        {
            BitsPerSample = 8;
            BytesPerFrame = 1;
        }

    }
}
