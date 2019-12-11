using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidationBuilder.Builder;
using FluentValidationBuilder.Extension;
using FluentValidationBuilder.Model.ActiveMessage;
using FluentValidationBuilder.Model.Transcode;
using FluentValidationBuilderData;
using FluentValidationBuilderData.TranscodeFormat.DataQuery;
using FluentValidationBuilderData.TranscodeFormat.Model;

namespace FluentValidationBuilder
{
    public interface ICommand
    {
    }

    public interface IValidationResult
    {
        bool IsValid { get; }
        string[] Errors { get; set; }
    }

    public interface ICommandResult
    {
        IValidationResult ValidationResult { get; set; }
    }

    public class ValidationResult : IValidationResult
    {
        public bool IsValid => !Errors?.Any() ?? true; // TODO right a test to check the logic here

        public string[] Errors { get; set; }
    }

    public interface ICommandHandler<in T1, T2> where T1 : ICommand
        where T2 : ICommandResult
    {
        ValueTask<T2> HandleAsync(T1 command, CancellationToken token = default);
    }

   

    public class TranscodeRequestHandler : ICommandHandler<TranscodeRequest,TranscodeResponse>
    {

        private readonly IValidator transcodeRequestValidator;
        private readonly IDataClient dataClient;

        public TranscodeRequestHandler(IValidator transcodeRequestValidator, IDataClient dataClient)
        {
            this.transcodeRequestValidator = transcodeRequestValidator;
            this.dataClient = dataClient;
        }


        public async ValueTask<TranscodeResponse> HandleAsync(TranscodeRequest command, CancellationToken token = default)
        {
            // logic here?

            // 1. validate the request
            // 2. check if the message is already in db in a waiting or progress state
            // 3. map message to active message
            // 4. insert into the database
            var transcodeResponse = new TranscodeResponse();

            var validationResult = await ValidateTranscodeRequest(command, token);
            if (!validationResult.IsValid)
            {
                return new TranscodeResponse() {ValidationResult = validationResult};
            }

            // lets query the database and return the format, settings, if the message exists already
            // database is a limited resource so use the most of it
            // perhaps create a transcode table for id, name, transcodepackage , settings, isclosedcaption
            // we should store the transcoderequest from the caller for audit purposes
            // todo: determine what information we need to retrieve from the database to builder the active message
            
            var transcodeFormats = await GetTranscodeFormats(command.Outputs.Select(m => m.Preset), token);

            var message = ActiveMessage
                .Builder()
                .with_transcode_request.build(command)
                .with_transcode_formats.build(transcodeFormats)
                .compile();

            // insert

            // out we go
            
            return transcodeResponse;
        }


        private async ValueTask<IValidationResult> ValidateTranscodeRequest(TranscodeRequest transcodeRequest, CancellationToken token)
        {
            var transcodeValidationResult = await transcodeRequestValidator.ValidateAsync(transcodeRequest, token);
            if (transcodeValidationResult.IsValid)
            {
                return new ValidationResult();
            }
            return transcodeValidationResult.Errors.Map();
        }

        private async ValueTask<IEnumerable<TranscodeResponse>> GetTranscodeFormats(IEnumerable<string> presets, CancellationToken token)
        {
            var query = new GetTranscodeFormatQuery(presets);
            return await dataClient.Query<TranscodeResponse>(query, token);
        }
    }
}
