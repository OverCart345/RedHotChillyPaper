namespace RedHotChillyPaper
{
    internal class Program
    {
        static void Main(string[] args)
        {

            const int inf = int.MaxValue;

            int[,] mass = { 
            {inf,12,22,28,32},                           
            {12,inf,10,40,20},
            {22,10,inf,50,10},                       
            {28,27,17,inf,27},                      
            {32,20,10,60,inf}};

            int size = mass.GetLength(0);

            int answer = 0;
            int choice_One = -1;
            int choice_Two = -1;


            while (size >= 2) 
            {
                int temp_answer = 0;

                for (int i = 0; i < size; i++) //нахождение минимальных чисел в строках и вычитание
                {
                    int min = inf;

                    for (int j = 0; j < size; j++)
                        min = Math.Min(min, mass[i, j]);

                    temp_answer += min;

                    for (int k = 0; k < size; k++)
                        if (mass[i,k] != inf)
                            mass[i, k] -= min;                    
                }


                for (int i = 0; i < size; i++)  //нахождение минимальных чисел в столбцах и вычитание
                {
                    int min = inf;

                    for (int j = 0; j < size; j++)
                        min = Math.Min(min, mass[j, i]);

                    temp_answer += min;

                    for (int k = 0; k < size; k++)
                        if (mass[k,i] != inf)
                            mass[k,i] -= min;                    
                }

                choice_Two = temp_answer;

                Console.WriteLine($"Выбор 1 - {choice_One} выбор 2 - {choice_Two}");

                if (choice_One == -1) //обновление ответа
                {
                    answer += choice_Two;
                }
                else if (choice_One <= choice_Two)
                {
                    answer += choice_One;
                }
                else if (choice_One > choice_Two) 
                {
                    answer += choice_Two;
                }

                //int[,] NULL_mass = new int[size, size];

                int max = 0;
                int drop_Line = -1;
                int drop_colum = -1;

          

                for (int i = 0; i < size; i++) // считаем степени нулей | находим наибольшую из степеней | находим что вычеркнуть
                    {

                        for (int j = 0; j < size; j++)
                        {
                            if (mass[i, j] == 0) 
                            {
                                int min1 = inf;
                                for (int k = 0; k < size; k++)
                                {
                                    if (k != j)
                                        min1 = Math.Min(min1, mass[i, k]);
                                    
                                }

                                int min2 = inf;
                                for (int k = 0; k < size; k++)
                                {
                                    if(k != i)
                                        min2 = Math.Min(min2, mass[k, j]);
                                
                                }

                            
                                if (min1 + min2 > max)
                                {
                                    max = min1 + min2;
                                    drop_Line = i;
                                    drop_colum = j;
                                }
                            }

                        }
                    }

                //Console.WriteLine("промежуточный = " + answer);
                //Console.WriteLine($"Строка {drop_Line + 1} столбец {drop_colum + 1}");

                choice_One = max;
                size--;
                //mass[drop_colum, drop_Line] = inf;

                for (int i = 0, a = 0; i < size; i++, a++) //удаление строки и столбца
                {
                    if (i == drop_Line)
                        a++;

                    for (int j = 0, b = 0; j < size; j++, b++)
                    {

                        if (j == drop_colum)
                        {
                            b++;                       
                        }

                        if (b == drop_colum && a == drop_Line)                      
                            mass[i, j] = inf;                                                   
                        else
                            mass[i, j] = mass[a, b];




                    }
                }

                
            }



           

            Console.WriteLine("Ответ = " + answer);

            Console.ReadKey();
        }
    }
}