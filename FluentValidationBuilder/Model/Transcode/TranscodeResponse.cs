namespace FluentValidationBuilder.Model.Transcode
{
    public class TranscodeResponse: ICommandResult
    {
        public int Id { get; set; }

        public IValidationResult ValidationResult { get; set; }
    }
}