namespace FluentValidationBuilder.Model.ActiveMessage
{
    public enum ActiveMessageStatus
    {
        Waiting = 1,
        InProgress = 2,
        Completed = 3,
        Failed = 4,
        Replaced = 5,
        Timeout_External = 6,
        Timeout_Internal = 7,
        Cancelled = 8,
        Ignored = 9,
        DeliveringResponse = 10,
        ResponseDelivered = 11,
        ResponseIgnored = 12,
        Dispatching = 13
    }
}