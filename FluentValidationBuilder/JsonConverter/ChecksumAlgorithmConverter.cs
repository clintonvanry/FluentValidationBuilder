using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using FluentValidationBuilder.Model;
using FluentValidationBuilder.Model.Transcode;

namespace FluentValidationBuilder.JsonConverter
{
    public class ChecksumAlgorithmConverter : JsonConverter<ChecksumAlgorithmType>
    {
        public override ChecksumAlgorithmType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var valueFromJson = reader.GetString() ?? string.Empty;
            var result = ChecksumAlgorithmType.None;
            
            if (string.IsNullOrEmpty(valueFromJson))
            {
                return result;
            }

            switch (valueFromJson.ToLower().Trim())
            {
                case "none":
                {
                    result = ChecksumAlgorithmType.None;
                    break;

                }
                case "sha1":
                {
                    result = ChecksumAlgorithmType.SHA1;
                    break;

                }
                case "sha256":
                {
                    result = ChecksumAlgorithmType.SHA256;
                    break;

                }
                case "sha512":
                {
                    result = ChecksumAlgorithmType.SHA512;
                    break;

                }
                case "md5":
                {
                    result = ChecksumAlgorithmType.MD5;
                    break;


                }
                default:
                {
                    result = ChecksumAlgorithmType.None;
                    break;
                }
            }

            return result;
        }

        public override void Write(Utf8JsonWriter writer, ChecksumAlgorithmType value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(Enum.GetName(typeof(ChecksumAlgorithmType), value));
        }
    }
}
