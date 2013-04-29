using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klockRepro.Business
{
    public class ChronoControler
    {
        private Dictionary<char, int[,]> numericDictionnary;
        private TimeSpan Duration;
        private DateTime StartTime;
        private DateTime LastTime;

        public ObservableCollection<DisplayLetter> DurationToDisplay { get; private set; }

        public ChronoControler()
        {
            DurationToDisplay = new ObservableCollection<DisplayLetter>();
            numericDictionnary = new Dictionary<char, int[,]>();
            numericDictionnary.Add('0', new int[,] {{-1,-1,0,0,0,0,0,-1,-1,-1},
                                                    {-1,0,0,-1,-1,-1,0,0,-1,-1},
                                                    {0,0,-1,-1,-1,-1,-1,0,0,-1},
                                                    {0,0,-1,-1,-1,-1,-1,0,0,-1},
                                                    {0,0,-1,-1,-1,-1,-1,0,0,-1},
                                                    {0,0,-1,-1,-1,-1,-1,0,0,-1},
                                                    {0,0,-1,-1,-1,-1,-1,0,0,-1},
                                                    {-1,0,0,-1,-1,-1,0,0,-1,-1},
                                                    {-1,-1,0,0,0,0,0,-1,-1,-1}
                                    });

            numericDictionnary.Add('1', new int[,] {{-1,-1,-1,-1,1,1,-1,-1,-1,-1},
                                                    {-1,-1,1,1,1,1,-1,-1,-1,-1},
                                                    {-1,-1,-1,-1,1,1,-1,-1,-1,-1},
                                                    {-1,-1,-1,-1,1,1,-1,-1,-1,-1},
                                                    {-1,-1,-1,-1,1,1,-1,-1,-1,-1},
                                                    {-1,-1,-1,-1,1,1,-1,-1,-1,-1},
                                                    {-1,-1,-1,-1,1,1,-1,-1,-1,-1},
                                                    {-1,-1,-1,-1,1,1,-1,-1,-1,-1},
                                                    {-1,-1,1,1,1,1,1,1,-1,-1}
                                   });

            numericDictionnary.Add('2', new int[,] {{-1,-1,2,2,2,2,2,2,2,-1},
                                                    {-1,2,2,-1,-1,-1,-1,-1,2,2},
                                                    {-1,-1,-1,-1,-1,-1,-1,-1,2,2},
                                                    {-1,-1,-1,-1,-1,-1,-1,-1,2,2},
                                                    {-1,-1,2,2,2,2,2,2,2,-1},
                                                    {-1,2,2,-1,-1,-1,-1,-1,-1,-1},
                                                    {-1,2,2,-1,-1,-1,-1,-1,-1,-1},
                                                    {-1,2,2,-1,-1,-1,-1,-1,-1,-1},
                                                    {-1,2,2,2,2,2,2,2,2,2}
                                    });

            numericDictionnary.Add('3', new int[,] {{-1,-1,3,3,3,3,3,3,3,-1},
                                                    {-1,3,3,-1,-1,-1,-1,-1,3,3},
                                                    {-1,-1,-1,-1,-1,-1,-1,-1,3,3},
                                                    {-1,-1,-1,-1,-1,-1,-1,-1,3,3},
                                                    {-1,-1,3,3,3,3,3,3,3,-1},
                                                    {-1,-1,-1,-1,-1,-1,-1,-1,3,3},
                                                    {-1,-1,-1,-1,-1,-1,-1,-1,3,3},
                                                    {-1,3,3,-1,-1,-1,-1,-1,3,3},
                                                    {-1,-1,3,3,3,3,3,3,3,-1}
                                    });

            numericDictionnary.Add('4', new int[,] {{-1,4,4,-1,-1,-1,-1,-1,-1,-1},
                                                    {-1,4,4,-1,-1,-1,-1,4,4,-1},
                                                    {-1,4,4,-1,-1,-1,-1,4,4,-1},
                                                    {-1,4,4,-1,-1,-1,-1,4,4,-1},
                                                    {-1,4,4,4,4,4,4,4,4,4},
                                                    {-1,-1,-1,-1,-1,-1,-1,4,4,-1},
                                                    {-1,-1,-1,-1,-1,-1,-1,4,4,-1},
                                                    {-1,-1,-1,-1,-1,-1,-1,4,4,-1},
                                                    {-1,-1,-1,-1,-1,-1,-1,4,4,-1}
                                    });

            numericDictionnary.Add('5', new int[,] {{-1,-1,5,5,5,5,5,5,5,5},
                                                    {-1,-1,5,5,-1,-1,-1,-1,-1,-1},
                                                    {-1,-1,5,5,-1,-1,-1,-1,-1,-1},
                                                    {-1,-1,5,5,-1,-1,-1,-1,-1,-1},
                                                    {-1,-1,5,5,5,5,5,5,5,-1},
                                                    {-1,-1,-1,-1,-1,-1,-1,-1,5,5},
                                                    {-1,-1,-1,-1,-1,-1,-1,-1,5,5},
                                                    {-1,-1,5,5,-1,-1,-1,-1,5,5},
                                                    {-1,-1,-1,5,5,5,5,5,5,-1}
                                    });

            numericDictionnary.Add('6', new int[,] {{-1,-1,6,6,6,6,6,6,6,-1},
                                                    {-1,6,6,-1,-1,-1,-1,-1,6,6},
                                                    {-1,6,6,-1,-1,-1,-1,-1,-1,-1},
                                                    {-1,6,6,-1,-1,-1,-1,-1,-1,-1},
                                                    {-1,6,6,6,6,6,6,6,6,-1},
                                                    {-1,6,6,-1,-1,-1,-1,-1,6,6},
                                                    {-1,6,6,-1,-1,-1,-1,-1,6,6},
                                                    {-1,6,6,-1,-1,-1,-1,-1,6,6},
                                                    {-1,-1,6,6,6,6,6,6,6,-1}
                                    });

            numericDictionnary.Add('7', new int[,] {{-1,7,7,7,7,7,7,7,7,-1},
                                                    {-1,7,7,-1,-1,-1,-1,7,7,-1},
                                                    {-1,-1,-1,-1,-1,7,7,-1,-1,-1},
                                                    {-1,-1,-1,-1,7,7,-1,-1,-1,-1},
                                                    {-1,-1,-1,7,7,-1,-1,-1,-1,-1},
                                                    {-1,-1,-1,7,7,-1,-1,-1,-1,-1},
                                                    {-1,-1,-1,7,7,-1,-1,-1,-1,-1},
                                                    {-1,-1,-1,7,7,-1,-1,-1,-1,-1},
                                                    {-1,-1,-1,7,7,-1,-1,-1,-1,-1}
                                    });

            numericDictionnary.Add('8', new int[,] {{-1,-1,8,8,8,8,8,8,8,-1},
                                                    {-1,8,8,-1,-1,-1,-1,-1,8,8},
                                                    {-1,8,8,-1,-1,-1,-1,-1,8,8},
                                                    {-1,8,8,-1,-1,-1,-1,-1,8,8},
                                                    {-1,-1,8,8,8,8,8,8,8,-1},
                                                    {-1,8,8,-1,-1,-1,-1,-1,8,8},
                                                    {-1,8,8,-1,-1,-1,-1,-1,8,8},
                                                    {-1,8,8,-1,-1,-1,-1,-1,8,8},
                                                    {-1,-1,8,8,8,8,8,8,8,-1}
                                    });

            numericDictionnary.Add('9', new int[,] {{-1,-1,9,9,9,9,9,9,9,-1},
                                                    {-1,9,9,-1,-1,-1,-1,-1,9,9},
                                                    {-1,9,9,-1,-1,-1,-1,-1,9,9},
                                                    {-1,9,9,-1,-1,-1,-1,-1,9,9},
                                                    {-1,-1,9,9,9,9,9,9,9,9},
                                                    {-1,-1,-1,-1,-1,-1,-1,-1,9,9},
                                                    {-1,-1,-1,-1,-1,-1,-1,-1,9,9},
                                                    {-1,9,9,-1,-1,-1,-1,-1,9,9},
                                                    {-1,-1,9,9,9,9,9,9,9,-1}
                                    });

            numericDictionnary.Add(':', new int[,] {{-1,-1,-2,-2,-1,-1},
                                                    {-1,-2,-2,-2,-2,-1},
                                                    {-1,-1,-2,-2,-1,-1},
                                                    {-1,-1,-1,-1,-1,-1},
                                                    {-1,-1,-1,-1,-1,-1},
                                                    {-1,-1,-1,-1,-1,-1},
                                                    {-1,-1,-2,-2,-1,-1},
                                                    {-1,-2,-2,-2,-2,-1},
                                                    {-1,-1,-2,-2,-1,-1}
                                    });


        }


        private IEnumerable<int[,]> Convert(string duration)
        {
            foreach (char c in duration)
            {
                yield return numericDictionnary[c];
            }
        }

        public async void IncrementeSeconde()
        {
            Duration = Duration.Add(TimeSpan.FromSeconds(1));
            await UpdateDisplayLettersSecondeAsync(Duration);
        }

        public async void TryIncrementeSeconde()
        {
            if (DateTime.Now.Subtract(LastTime).TotalMilliseconds > 850)
            {
                IncrementeSeconde();
                LastTime = DateTime.Now;
            }
        }

        public async void Start()
        {
            if (StartTime == DateTime.MinValue)
            {
                StartTime = DateTime.Now;
                Duration = TimeSpan.FromSeconds(0);
                await UpdateDisplayLettersSecondeAsync(Duration);
            }
            LastTime = DateTime.Now;
        }

        public void Pause()
        {
        }

        public  void Stop(bool andDisplay = false)
        {
            StartTime = LastTime = DateTime.MinValue;
            Duration = TimeSpan.FromSeconds(0);
            //if(andDisplay)
            //     UpdateDisplayLettersSecondeAsync(Duration);
        }

        private async Task UpdateDisplayLettersSecondeAsync(TimeSpan duration)
        {
            IEnumerable<int[,]> chiffres = null;

            if (duration.Minutes == 0 && duration.Seconds == 0)
            {
                if (duration.Hours % 10 == 0)
                {
                    RemoveDigits(DIGITS_2_HEURE);
                    chiffres = Convert(duration.ToString("hh':'mm':'ss"));
                }
                else
                {
                    RemoveDigits(DIGITS_1_HEURE);
                    chiffres = Convert(duration.ToString("hh':'mm':'ss").Substring(1));
                }
            }
            else
            {
                if (duration.Seconds == 0)
                {
                    if (duration.Minutes % 10 == 0)
                    {
                        RemoveDigits(DIGITS_2_MINUTE);
                        chiffres = Convert(duration.ToString("mm':'ss"));
                    }
                    else
                    {
                        RemoveDigits(DIGITS_1_MINUTE);
                        chiffres = Convert(duration.ToString("mm':'ss").Substring(1));
                    }
                }
                else
                {
                    if (duration.Seconds % 10 == 0)
                    {
                        RemoveDigits(DIGITS_2_SECONDE);
                        chiffres = Convert(duration.ToString("ss"));
                    }
                    else
                    {
                        RemoveDigits(DIGITS_1_SECONDE);
                        chiffres = Convert(duration.ToString("ss").Substring(1));
                    }
                }
            }
            
            AddChiffresToDisplayLetter(chiffres);
        }

        private async Task GetDisplayLettersAsync(TimeSpan duration)
        {
            DurationToDisplay.Clear();
            IEnumerable<int[,]> chiffres = Convert(duration.ToString("hh':'mm':'ss"));
            AddChiffresToDisplayLetter(chiffres);
        }

        private void AddChiffresToDisplayLetter(IEnumerable<int[,]> chiffres)
        {
            foreach (int[,] chiffre in chiffres.AsParallel())
            {
                for (int j = 0; j < chiffre.GetLength(1); j++)
                {
                    for (int i = 0; i < chiffre.GetLength(0); i++)
                    {
                        DisplayLetter letter;
                        if (chiffre[i, j] == -1)
                        {
                            letter = new DisplayLetter() { Name = " ", Active = false };
                        }
                        else if (chiffre[i, j] == -2)
                        {
                            letter = new DisplayLetter() { Name = "*", Active = true };
                        }
                        else
                        {
                            letter = new DisplayLetter() { Name = chiffre[i, j].ToString(), Active = true };
                        }
                        DurationToDisplay.Add(letter);
                    }
                }
            }
        }

        private const int DIGITS_2_SECONDE = 468;
        private const int DIGITS_1_SECONDE = 558;
        private const int DIGITS_2_MINUTE = 234;
        private const int DIGITS_1_MINUTE = 324;
        private const int DIGITS_2_HEURE = 0;
        private const int DIGITS_1_HEURE = 90;

        private void RemoveDigits(int FromNbDigits,  int ToNbDigits = 0)
        {
            while (DurationToDisplay.Count > FromNbDigits)
            {
                DurationToDisplay.RemoveAt(FromNbDigits);
            }
        }


    }
}





