namespace Task3.Services;

public class CalculateService : ICalculateService
{
    public string CreateNumber()
    {
        try
        {
            var random = new Random();
            string number = "";

            for (int i = 0; i < 4; i++)
            {
              sameNumber :
              int a = random.Next(0,9);

              if(!number.Contains(a.ToString()))
              {
                number = number+a;
              }
              else goto sameNumber;
            }

            return number;
            
        }
        catch (System.Exception)
        {
            throw new Exception();
        }
    }

    public int[] ValidateDigits(string number, string insertNumber)
    {
       try
       {
          int m = 0;
          int p = 0;
          var numberArray = ToArray(number);
          var insertNumberArray =  ToArray(insertNumber.ToString());

          for (int i = 0; i < 4; i++)
          {
            for (int j = 0; j < 4; j++)
            {
               if(numberArray[i] == insertNumberArray[j])
               {
                m++;
               } 
            }

             if(numberArray[i] == insertNumberArray[i])
               {
                p++;
               } 
          }

          int[] result = {m-p,p};
          return result;
       }
       catch (System.Exception)
       {
        throw;
       }
    }
     private int[] ToArray(string number)
    {
        int[] array = new int[number.Length];

        for (int i = 0; i < number.Length; i++)
        {
            array[i] = int.Parse(number[i].ToString());
        }

        return array;
    }
}