using TicketSystem.Domain.Enum;

namespace TicketSystem.Application.DTOs
{
    public record Result<T>(
        bool IsSuccess,
        string Message,
        T? Data,
        ErrorType? ErrorType = null
    );
}