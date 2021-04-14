using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Homework1
{
    class Program
    {
        static void Main(string[] args)
        {

            var reader = new StreamReader(File.OpenRead("referendum_result.csv"));
            List<Vote> voteList = new List<Vote>();
            List<bool> resultList = new List<bool>();
            float passNumber = 0;
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(",");
                Vote vote = Vote.CreateFormCSV(values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7], values[8], values[9]);
                voteList.Add(vote);


                for (int i = 0; i < values.Length; i++)
                {
                    Console.Write(values[i] + " ");
                }
                Console.Write("\n");
                if (vote.Result == "通過")
                {
                    resultList.Add(true);
                }
                else
                {
                    resultList.Add(false);
                }
            }
            //resultList.ForEach(delegate (bool value)
            //{
            //    if (value == true)
            //    {
            //        passNumber += 1;

            //    }
            //});

            passNumber = resultList.Count(x => x == true);
            Console.WriteLine("法案通過率" + ((passNumber) / (resultList.Count) * 100).ToString() + "%");

        }
    }

}
public class Vote
{
    public string Number { get; set; }//a
    public string AllPopulation { get; set; }//b
    public string Agree { get; set; }//c
    public string NotAgree { get; set; }//d
    public string Avaliable { get; set; }//e
    public string NotAvalible { get; set; }//f
    public string RealPopulation { get; set; }//g
    public string VotingRate { get; set; }//h
    public string AgreeToAllRate { get; set; }//i
    public string Result { get; set; }//j
    public Vote() { }
    private Vote(string a, string b, string c, string d, string e, string f, string g, string h, string i, string j)
    {
        this.Number = a;
        this.AllPopulation = b;
        this.Agree = c;
        this.NotAgree = d;
        this.Avaliable = e;
        this.NotAvalible = f;
        this.RealPopulation = g;
        this.VotingRate = h;
        this.AgreeToAllRate = i;
        this.Result = j;
    }

    public static Vote CreateFormCSV(string a, string b, string c, string d, string e, string f, string g, string h, string i, string j)
    {
        return new Vote(a, b, c, d, e, f, g, h, i, j);
    }
    public static List<Vote> readData()
    {
        var reader = new StreamReader(File.OpenRead("referendum_result.csv"));
        List<Vote> voteList = new List<Vote>();
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            var values = line.Split(",");
            Vote vote = Vote.CreateFormCSV(values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7], values[8], values[9]);
            voteList.Add(vote);
        }
        return voteList;
    }

}
