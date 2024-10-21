using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;
    
    
//Question 1
Console.Write("Enter your name: ");
string name = Console.ReadLine();

Console.Write("Enter your birthdate: ");
string birth_date = Console.ReadLine();
DateTime birthDate;


// Question 2
while (true) {
    Console.Write("Enter your birthdate (MM/dd/yyyy): ");
    birth_date = Console.ReadLine();
    if (Regex.IsMatch(birth_date, @"^(0[1-9]|1[0-2])\/(0[1-9]|[12][0-9]|3[01])\/(19|20)\d{2}$"))
    {
        if (DateTime.TryParseExact(birth_date, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out birthDate))
        {
            break;
        }
    }
    Console.WriteLine("Invalid birthdate format. Please try again.");
}

// Question 3
int age = DateTime.Now.Year - birthDate.Year;
if (DateTime.Now < birthDate.AddYears(age)) {
    age--;
}
Console.WriteLine($"Hello {name}, you are {age} years old.");

// Question 4
string userInfo = $"Name: {name}\nBirthdate: {birthDate.ToString("MM/dd/yyyy")}\nAge: {age}\n";
const string file_name = "user_info.txt";
using (StreamWriter sw = File.CreateText(file_name)) {
    sw.WriteLine(userInfo);
}


// Question 5
string user_info_content = File.ReadAllText(file_name);
Console.WriteLine(user_info_content);


// Question 6
Console.Write("Enter a directory path: ");
string directory_path = Console.ReadLine();

// Question 7
if (Directory.Exists(directory_path)) {
    string[] files = Directory.GetFiles(directory_path);
    Console.WriteLine("Files in the specified directory:");
    foreach (string file in files) {
        Console.WriteLine(Path.GetFileName(file));
    }
}
else {
    Console.WriteLine("The specified directory does not exist.");
}

// Question 8
Console.Write("Enter a string: ");
string entered_string = Console.ReadLine();

// Question 9
TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
string formattedString = textInfo.ToTitleCase(entered_string.ToLower());
Console.WriteLine($"Formatted string in title case: {formattedString}");

// Question 10
GC.Collect();
