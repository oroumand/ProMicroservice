﻿namespace Zamin.Utilities.DateTimes;
/// <summary>
/// DateTimeOffset Part
/// سورس این بخش در ابتدا از مجموعه کارهای آقای وحید نصیری برداشته شده است. پس از تکمیل و اصلاحات نهایی آدرس دهی و ... اصلاح می‌شود
/// </summary>
public enum DateTimeOffsetPart
{
    /// <summary>
    /// قسمت زمان مقدار را بدون توجه به آفست باز می‌گرداند و به زمان محلی سرور تبدیل نخواهد شد
    /// </summary>
    DateTime,

    /// <summary>
    /// قسمت زمان را با توجه به منطقه زمانی سروری که برنامه بر روی آن اجرا می‌شود، بر می‌گرداند
    /// </summary>
    LocalDateTime,

    /// <summary>
    /// The Coordinated Universal Time (UTC) date and time of the current System.DateTimeOffset
    /// </summary>
    UtcDateTime,

    /// <summary>
    /// این وهله را به منطقه‌ی زمانی ایران تبدیل و مقدار را بر می‌گرداند
    /// </summary>
    IranLocalDateTime
}
