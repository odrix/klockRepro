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
        private TimeSpan LastDuration;

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
                                                    {-1,0,0,-1,-1,-1,0,0,-1,-1},
                                                    {-1,-1,0,0,0,0,0,-1,-1,-1}
                                    });

            numericDictionnary.Add('1', new int[,] {{-1,-1,-1,-1,1,1,-1,-1,-1,-1},
                                                    {-1,-1,1,1,1,1,-1,-1,-1,-1},
                                                    {-1,-1,-1,-1,1,1,-1,-1,-1,-1},
                                                    {-1,-1,-1,-1,1,1,-1,-1,-1,-1},
                                                    {-1,-1,-1,-1,1,1,-1,-1,-1,-1},
                                                    {-1,-1,-1,-1,1,1,-1,-1,-1,-1},
                                                    {-1,-1,1,1,1,1,1,1,-1,-1}
                                   });

            numericDictionnary.Add('2', new int[,] {{-1,-1,2,2,2,2,2,2,2,-1},
                                                    {-1,2,2,-1,-1,-1,-1,-1,2,2},
                                                    {-1,-1,-1,-1,-1,-1,-1,-1,2,2},
                                                    {-1,-1,2,2,2,2,2,2,2,-1},
                                                    {-1,2,2,-1,-1,-1,-1,-1,-1,-1},
                                                    {-1,2,2,-1,-1,-1,-1,-1,-1,-1},
                                                    {-1,2,2,2,2,2,2,2,2,2}
                                    });

            numericDictionnary.Add('3', new int[,] {{-1,-1,3,3,3,3,3,3,3,-1},
                                                    {-1,3,3,-1,-1,-1,-1,-1,3,3},
                                                    {-1,-1,-1,-1,-1,-1,-1,-1,3,3},
                                                    {-1,-1,3,3,3,3,3,3,3,-1},
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
                                                    {-1,-1,-1,-1,-1,-1,-1,4,4,-1}
                                    });

            numericDictionnary.Add('5', new int[,] {{-1,-1,5,5,5,5,5,5,5,5},
                                                    {-1,-1,5,5,-1,-1,-1,-1,-1,-1},
                                                    {-1,-1,5,5,-1,-1,-1,-1,-1,-1},
                                                    {-1,-1,5,5,5,5,5,5,5,-1},
                                                    {-1,-1,-1,-1,-1,-1,-1,-1,5,5},
                                                    {-1,-1,5,5,-1,-1,-1,-1,5,5},
                                                    {-1,-1,-1,5,5,5,5,5,5,-1}
                                    });

            numericDictionnary.Add('6', new int[,] {{-1,-1,6,6,6,6,6,6,6,-1},
                                                    {-1,6,6,-1,-1,-1,-1,-1,6,6},
                                                    {-1,6,6,-1,-1,-1,-1,-1,-1,-1},
                                                    {-1,6,6,6,6,6,6,6,6,-1},
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
                                                    {-1,-1,-1,7,7,-1,-1,-1,-1,-1}
                                    });

            numericDictionnary.Add('8', new int[,] {{-1,-1,8,8,8,8,8,8,8,-1},
                                                    {-1,8,8,-1,-1,-1,-1,-1,8,8},
                                                    {-1,8,8,-1,-1,-1,-1,-1,8,8},
                                                    {-1,-1,8,8,8,8,8,8,8,-1},
                                                    {-1,8,8,-1,-1,-1,-1,-1,8,8},
                                                    {-1,8,8,-1,-1,-1,-1,-1,8,8},
                                                    {-1,-1,8,8,8,8,8,8,8,-1}
                                    });

            numericDictionnary.Add('9', new int[,] {{-1,-1,9,9,9,9,9,9,9,-1},
                                                    {-1,9,9,-1,-1,-1,-1,-1,9,9},
                                                    {-1,9,9,-1,-1,-1,-1,-1,9,9},
                                                    {-1,-1,9,9,9,9,9,9,9,9},
                                                    {-1,-1,-1,-1,-1,-1,-1,-1,9,9},
                                                    {-1,9,9,-1,-1,-1,-1,-1,9,9},
                                                    {-1,-1,9,9,9,9,9,9,9,-1}
                                    });

            numericDictionnary.Add(':', new int[,] {{-1,-1,-2,-2,-1,-1},
                                                    {-1,-2,-2,-2,-2,-1},
                                                    {-1,-1,-2,-2,-1,-1},
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

        public async void Reinit()
        {
            Duration = TimeSpan.FromSeconds(0);
            LastDuration = Duration;
            await GetDisplayLettersAsync(Duration);
        }

        private async Task UpdateDisplayLettersSecondeAsync(TimeSpan duration)
        {
            RemoveSeconde();
            IEnumerable<int[,]> chiffres = Convert(duration.ToString("ss"));
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
            foreach (int[,] chiffre in chiffres)
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

        private void RemoveSeconde()
        {
            while (DurationToDisplay.Count > 364)
            {
                DurationToDisplay.RemoveAt(364);
            }
        }


    }
}





