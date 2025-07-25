﻿using System.Text.Json.Serialization;

namespace Shared;

public record Error
{
    public static Error None = new Error(string.Empty, string.Empty, ErrorType.None, null);
    public string Code { get; }

    public string Message { get; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ErrorType Type { get; }

    public string? InvalidField { get; }

    [JsonConstructor]
    private Error(string code, string message, ErrorType type, string? invalidField = null)
    {
        Code = code;
        Message = message;
        Type = type;
        InvalidField = invalidField;
    }

    public static Error NotFound(string? code, string message, string? invalidField = null) =>
        new Error(code ?? "record.not_found", message, ErrorType.NOT_FOUND, invalidField);

    public static Error Validation(string? code, string message, string? invalidField = null) =>
        new Error(code ?? "value.is_invalid", message, ErrorType.VALIDATION, invalidField);

    public static Error Conflict(string? code, string message, string? invalidField = null) =>
        new Error(code ?? "conflict", message, ErrorType.CONFLICT, invalidField);

    public static Error Failure(string? code, string message, string? invalidField = null) =>
        new Error(code ?? "failure", message, ErrorType.FAILURE, invalidField);

    public Failure ToFailure() => this;
}

public enum ErrorType
{
    /// <summary>
    /// неизвестная ошибка
    /// </summary>
    None,

    /// <summary>
    /// ошибка валидации
    /// </summary>
    VALIDATION,

    /// <summary>
    /// ошибка ничего не найдено
    /// </summary>
    NOT_FOUND,

    /// <summary>
    /// ошибка сервера
    /// </summary>
    FAILURE,

    /// <summary>
    /// ошибка-конфликт
    /// </summary>
    CONFLICT
}