using Microsoft.VisualBasic.FileIO;
using System.Globalization;

namespace MarathonFileUtils.Sounds.SoundIds
{
    public static class SoundIdLoader
    {

        #region Public Members

        public static List<SoundId> Marathon1SoundIds
        {
            get
            {
                if (mMarathon1SoundIds == null || mMarathon1SoundIds.Count == 0)
                {
                    LoadMarathon1SoundIds();
                }

                return mMarathon1SoundIds;
            }
        }

        public static List<SoundId> Marathon2SoundIds
        {
            get
            {
                if (mMarathon2SoundIds == null || mMarathon2SoundIds.Count == 0)
                {
                    LoadMarathon2SoundIds();
                }

                return mMarathon2SoundIds;
            }
        }

        public static List<SoundId> RubiconSoundIds
        {
            get
            {
                if (mRubiconSoundIds == null || mRubiconSoundIds.Count == 0)
                {
                    LoadRubiconSoundIds();
                }

                return mRubiconSoundIds;
            }
        }

        #endregion

        #region Private Members

        private static List<SoundId> mMarathon1SoundIds = new List<SoundId>();
        private static List<SoundId> mMarathon2SoundIds = new List<SoundId>();
        private static List<SoundId> mRubiconSoundIds = new List<SoundId>();

        private static void LoadMarathon1SoundIds()
        {
            mMarathon1SoundIds = Load("M1");
        }

        private static void LoadMarathon2SoundIds()
        {
            mMarathon2SoundIds = Load("M2");
        }

        private static void LoadRubiconSoundIds()
        {
            mRubiconSoundIds = Load("Rubicon");
        }

        #endregion

        #region Private Members

        private static List<SoundId> Load(string csvName)
        {
            if (string.IsNullOrWhiteSpace(csvName))
            {
                throw new ArgumentException("A CSV name must be provided.", nameof(csvName));
            }

            string csvPath = Path.Combine(AppContext.BaseDirectory, "Sounds", "SoundIds", $"{csvName}.csv");

            if (!System.IO.File.Exists(csvPath))
            {
                throw new System.IO.FileNotFoundException("The sound ID CSV file was not found.", csvPath);
            }

            List<SoundId> soundIds = new List<SoundId>();

            using (TextFieldParser parser = new TextFieldParser(csvPath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                parser.HasFieldsEnclosedInQuotes = true;
                parser.TrimWhiteSpace = true;

                int lineNumber = 0;

                // Read and validate the header.
                if (parser.EndOfData)
                {
                    throw new InvalidOperationException("The sound ID CSV file is empty.");
                }

                string[] headers = parser.ReadFields();
                lineNumber++;

                while (!parser.EndOfData)
                {
                    string[] fields;

                    try
                    {
                        fields = parser.ReadFields();
                        lineNumber++;
                    }
                    catch (MalformedLineException exception)
                    {
                        throw new InvalidOperationException("Malformed CSV data near line " + parser.ErrorLineNumber + ".", exception);
                    }

                    if (fields == null || IsEmptyRow(fields))
                    {
                        continue;
                    }

                    short id = ParseShort(fields[0], "Id", lineNumber);

                    int index = ParseInteger(fields[1], "Index", lineNumber);

                    string name = fields[2];

                    if (string.IsNullOrWhiteSpace(name))
                    {
                        throw new InvalidOperationException("Name is empty on line " + lineNumber + ".");
                    }

                    SoundId soundId = new SoundId(id, index, name);

                    soundIds.Add(soundId);
                }
            }

            return soundIds;
        }

        private static int ParseInteger(string value, string columnName, int lineNumber)
        {
            int result;

            if (!int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out result))
            {
                throw new InvalidOperationException("The value '" + value + "' in column '" + columnName + "' on line " + lineNumber + " is not a valid 32-bit signed integer.");
            }

            return result;
        }

        private static short ParseShort(string value, string columnName, int lineNumber)
        {
            short result;

            if (!short.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out result))
            {
                throw new InvalidOperationException("The value '" + value + "' in column '" + columnName + "' on line " + lineNumber + " is not a valid 16-bit signed integer.");
            }

            return result;
        }

        private static bool IsEmptyRow(string[] fields)
        {
            for (int index = 0; index < fields.Length; index++)
            {
                if (!string.IsNullOrWhiteSpace(fields[index]))
                {
                    return false;
                }
            }

            return true;
        }

        #endregion

    }
}
