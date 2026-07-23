using System;
using System.ComponentModel;
using System.Reflection;

namespace Common
{
	/// <summary>
	/// کلاس ابزارهای کمکی که در تمام لایه‌های برنامه قابل استفاده است
	/// </summary>
	public static class Extensions : object
	{
		// **********
		/// <summary>
		/// تبدیل تاریخ میلادی دیتابیس به رشته تاریخ شمسی برای نمایش در فرم‌ها
		/// </summary>
		public static string ToJalali(this System.DateTime date)
		{
			try
			{
				System.Globalization.PersianCalendar persianCalendar =
					new System.Globalization.PersianCalendar();

				int year = persianCalendar.GetYear(date);
				int month = persianCalendar.GetMonth(date);
				int day = persianCalendar.GetDayOfMonth(date);

				// فرمت کردن به صورت 1403/05/09 (اضافه کردن صفر پشت ماه‌ها و روزهای یک رقمی)
				string result =
					$"{year}/{month.ToString().PadLeft(2, '0')}/{day.ToString().PadLeft(2, '0')}";

				return result;
			}
			catch (System.Exception)
			{
				return "تاریخ نامعتبر";
			}
		}
		// **********

		// **********
		/// <summary>
		/// تبدیل رشته تاریخ شمسی (ورودی کاربر) به تاریخ میلادی برای ذخیره در دیتابیس
		/// </summary>
		/// <param name="jalaliDate">رشته تاریخ شمسی مثلا 1370/05/12</param>
		/// <returns>تاریخ میلادی. اگر فرمت اشتباه باشد Null برمی‌گرداند</returns>
		public static System.DateTime? ToGregorian(this string jalaliDate)
		{
			if (string.IsNullOrWhiteSpace(jalaliDate))
			{
				return null;
			}

			try
			{
				// جدا کردن سال، ماه و روز بر اساس کاراکتر اسلش
				string[] parts = jalaliDate.Split('/');

				if (parts.Length != 3)
				{
					return null; // فرمت اشتباه است
				}

				int year = int.Parse(parts[0]);
				int month = int.Parse(parts[1]);
				int day = int.Parse(parts[2]);

				// استفاده از تقویم شمسی برای ساخت تاریخ میلادی
				System.Globalization.PersianCalendar persianCalendar =
					new System.Globalization.PersianCalendar();

				// این خط جادوی اصلی است: مقادیر شمسی را می‌گیرد و DateTime میلادی می‌سازد
				System.DateTime gregorianDate =
					new System.DateTime(year, month, day, persianCalendar);

				return gregorianDate;
			}
			catch (System.Exception)
			{
				// اگر کاربر تاریخ نامعتبری وارد کرد (مثلا 1403/13/40)
				return null;
			}
		}
		// **********

		// **********
		/// <summary>
		/// استخراج متن فارسی (Description) از روی Enumها 
		/// مثل تبدیل Sexology.Male به "آقا"
		/// </summary>
		public static string GetDescription(this System.Enum enumValue)
		{
			try
			{
				// استخراج نوع (Type) آن Enum
				System.Type type = enumValue.GetType();

				// پیدا کردن فیلد مربوطه
				System.Reflection.FieldInfo fieldInfo = type.GetField(enumValue.ToString());

				if (fieldInfo != null)
				{
					// خواندن اتریبیوت Description از روی آن فیلد
					object[] attributes =
						fieldInfo.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);

					if (attributes != null && attributes.Length > 0)
					{
						// اگر اتریبیوت وجود داشت، متن آن را برگردان
						return ((System.ComponentModel.DescriptionAttribute)attributes[0]).Description;
					}
				}

				// اگر اتریبیوتی نداشت، همان نام انگلیسی را برگردان
				return enumValue.ToString();
			}
			catch (System.Exception)
			{
				return enumValue.ToString();
			}
		}
		// **********
	}
}