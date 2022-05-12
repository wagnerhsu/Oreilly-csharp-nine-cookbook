using System;
using System.Text.Json;

namespace Section_07_06;

public static class JsonConversionExtensions
{
    public static bool IsNull(this JsonElement json)
    {
        return
            json.ValueKind == JsonValueKind.Undefined ||
            json.ValueKind == JsonValueKind.Null;
    }

    public static string GetString(
        this JsonElement json,
        string propertyName,
        string defaultValue = default)
    {
        if (!json.IsNull() &&
            json.TryGetProperty(propertyName, out var element))
        {
            return element.GetString() ?? defaultValue;
        }

        return defaultValue;
    }

    public static int GetInt(
        this JsonElement json,
        string propertyName,
        int defaultValue = default)
    {
        if (!json.IsNull() &&
            json.TryGetProperty(propertyName, out var element) &&
            !element.IsNull() &&
            element.TryGetInt32(out var value))
        {
            return value;
        }

        return defaultValue;
    }

    public static ulong GetULong(
        this string val,
        ulong defaultValue = default)
    {
        return string.IsNullOrWhiteSpace(val) ||
               !ulong.TryParse(val, out var result)
            ? defaultValue
            : result;
    }

    public static ulong GetUlong(
        this JsonElement json,
        string propertyName,
        ulong defaultValue = default)
    {
        if (!json.IsNull() &&
            json.TryGetProperty(propertyName, out var element) &&
            !element.IsNull() &&
            element.TryGetUInt64(out var value))
        {
            return value;
        }

        return defaultValue;
    }

    public static long GetLong(
        this JsonElement json,
        string propertyName,
        long defaultValue = default)
    {
        if (!json.IsNull() &&
            json.TryGetProperty(propertyName, out var element) &&
            !element.IsNull() &&
            element.TryGetInt64(out var value))
        {
            return value;
        }

        return defaultValue;
    }

    public static bool GetBool(
        this JsonElement json,
        string propertyName,
        bool defaultValue = default)
    {
        if (!json.IsNull() &&
            json.TryGetProperty(propertyName, out var element) &&
            !element.IsNull())
        {
            return element.GetBoolean();
        }

        return defaultValue;
    }

    public static double GetDouble(
        this string val,
        double defaultValue = default)
    {
        return string.IsNullOrWhiteSpace(val) ||
               !double.TryParse(val, out var result)
            ? defaultValue
            : result;
    }

    public static double GetDouble(
        this JsonElement json,
        string propertyName,
        double defaultValue = default)
    {
        if (!json.IsNull() &&
            json.TryGetProperty(propertyName, out var element) &&
            !element.IsNull() &&
            element.TryGetDouble(out var value))
        {
            return value;
        }

        return defaultValue;
    }

    public static decimal GetDecimal(
        this JsonElement json,
        string propertyName,
        decimal defaultValue = default)
    {
        if (!json.IsNull() &&
            json.TryGetProperty(propertyName, out var element) &&
            !element.IsNull() &&
            element.TryGetDecimal(out var value))
        {
            return value;
        }

        return defaultValue;
    }

    public static TEnum GetEnum<TEnum>
    (this JsonElement json,
        string propertyName,
        TEnum defaultValue = default)
        where TEnum : struct
    {
        if (!json.IsNull() &&
            json.TryGetProperty(propertyName, out var element) &&
            !element.IsNull())
        {
            var enumString = element.GetString();

            if (enumString != null &&
                Enum.TryParse(enumString, out TEnum num))
            {
                return num;
            }
        }

        return defaultValue;
    }
}
