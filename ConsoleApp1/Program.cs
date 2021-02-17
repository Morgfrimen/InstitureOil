using System;
using System.Collections.Generic;

using LibOilWater;

const char commandWater = '1';
const char commandBear = '2';
const char commandNastya = '3';
const char commandExit = '0';
PrintHeader();

while (true)
{
    Console.WriteLine("Введите комманду");
    ConsoleKeyInfo key = Console.ReadKey();

    if (key.KeyChar == commandExit)
        return;

    switch (key.KeyChar)
    {
        case commandBear:
            RunTaskBear();

            break;

        case commandNastya:
            RunTaskNastya();

            break;

        case commandWater:
            RunTaskWater();

            break;

        default:
            continue;
    }

    Console.WriteLine("Введите следующую команду");
    key = Console.ReadKey();

    if (key.KeyChar == commandExit)
        return;

    Console.Clear();
    PrintHeader();
}

void PrintHeader()
{
    Console.WriteLine($"Для того,чтобы выйти из консоли нажмите {commandExit}");
    Console.WriteLine($"Для того,чтобы ввести данные и решить задачу с водой {commandWater}");
    Console.WriteLine($"Для того,чтобы ввести данные и решить задачу с медведем {commandBear}");
    Console.WriteLine($"Для того,чтобы ввести данные и решить задачу с Настей {commandNastya}");
    Console.WriteLine(Environment.NewLine);
}

void RunTaskWater()
{
    Console.WriteLine();
    Console.Write("Введите n: ");

    if (!int.TryParse(Console.ReadLine(), out int n))
        return;

    Console.WriteLine("Перечислите массив");
    List<uint> list = new();

    for (int index = 0; index < n; index++)
    {
        if (uint.TryParse(Console.ReadLine(), out uint value))
            list.Add(value);
    }

    IRunTask<uint> nastyaTask = CoreTask.GeCoreTask().GeWaterTaskUintValue(list);
    Console.WriteLine($"Результат: {nastyaTask.Run()}");
}

void RunTaskNastya()
{
    Console.WriteLine();
    Console.Write("Введите n: ");

    if (!int.TryParse(Console.ReadLine(), out int n))
        return;

    Console.WriteLine("Перечислите массив");
    List<int> list = new();

    for (int index = 0; index < n; index++)
    {
        if (int.TryParse(Console.ReadLine(), out int value))
            list.Add(value);
    }

    IRunTask<int> nastyaTask = CoreTask.GeCoreTask().GetNastyaTask(n, list);
    Console.WriteLine($"Результат: {nastyaTask.Run()}");
}

void RunTaskBear()
{
    Console.WriteLine();
    Console.Write("Введите n: ");

    if (!uint.TryParse(Console.ReadLine(), out uint n))
        return;

    Console.WriteLine();
    Console.WriteLine("Введите k: ");

    if (!uint.TryParse(Console.ReadLine(), out uint k))
        return;

    Console.WriteLine("Перечислите массив");
    List<uint> list = new();

    for (int index = 0; index < n; index++)
    {
        if (uint.TryParse(Console.ReadLine(), out uint value))
            list.Add(value);
    }

    IRunTask<uint> bear = CoreTask.GeCoreTask().GetBearTask(n, k, list);
    Console.WriteLine($"Результат: {bear.Run()}");
}