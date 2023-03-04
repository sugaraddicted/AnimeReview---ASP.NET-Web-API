using AnimeReview.Models;

namespace AnimeReview.Data
{
    public class DataInitializer
    {
        private readonly DataContext dataContext;

        public DataInitializer(DataContext context)
        {
            this.dataContext = context;
        }
        public void Seed()
        {
            if (!dataContext.AnimeGenres.Any())
            {
                if (!dataContext.AnimeGenres.Any())
                {
                    var pokemonOwners = new List<AnimeGenre>()
                    {
                        new AnimeGenre()
                        {
                            Anime = new Anime()
                            {
                                Name = "Chainsaw Man",
                                ReleaseDate = new DateTime(2022, 10, 12),
                                Description = "Denji is robbed of a normal teenage life, left with nothing but his deadbeat father's overwhelming debt. His only companion is his pet, the chainsaw devil Pochita, with whom he slays devils for money that inevitably ends up in the yakuza's pockets. All Denji can do is dream of a good, simple life: one with delicious food and a beautiful girlfriend by his side. But an act of greedy betrayal by the yakuza leads to Denji's brutal, untimely death, crushing all hope of him ever achieving happiness.",
                                Reviews = new List<Review>()
                                {
                                    new Review
                                    {
                                        Title = "Chainsaw Man review",
                                        Text = "Imagine this. You are about to watch a series sold as a hectic action with unexpected twists and chaotic energy. You are about to watch a series that has been declared revolutionary in its genre, a series that manipulated tropes to create something unique and distinguishable. Captivating, emotional, intelligent, entertaining, juvenile. Then, when you are about to watch the show, you see a fraudulent cinematic attempt with a disgusting production, a derivative storyline, and pathetic comedic timing. Yes, this happened. Yes, this is Chainsaw Man.",
                                        Reviewer = new Reviewer() { FullName = "Teddy Smith", NickName = "Gween_Gween" },
                                        Rating = 10
                                    },
                                    new Review
                                    {
                                        Title = "Chainsaw Man review",
                                        Text = "Chainsaw man is an action packed comedy and a mystery/horror anime with a spectrum of interesting characters and an amazing story that gets deeper as it progresses which makes it stand out above any other similar anime of the same genre.",
                                        Reviewer = new Reviewer() { FullName = "Nick Smith", NickName = "I-Watch-Anime" },
                                        Rating = 9
                                    },
                                    new Review
                                    {
                                        Title = "Chainsaw Man review",
                                        Text = "Why Chainsaw Man would even have a tad of bad reputation is baffling to me: it is close to being a perfect Shounen. While there are still definitely flaws, I can say with confidence that there are no deal-breakers in the series, as long as you are an anime fan.",
                                        Reviewer = new Reviewer() { FullName = "Tom Teddy", NickName = "rrakku" },
                                        Rating = 10
                                    },

                                },
                                Author = new Author()
                                {
                                    Name = "Tatsuki Fujimoto",
                                    Bio ="Tatsuki Fujimoto is a Japanese mangaka best known for his work Fire Punch and Chainsaw Man. He graduated from Nikaho High School in Akita Prefecture and Tohoku University of Art and Design, and studied at the Faculty of Fine Arts."

                                },
                                Country = new Country()
                                {
                                    Name = "Japan"
                                }
                            },
                            Genre = new Genre()
                            {
                                Name = "Action",
                                Description = "Exciting action sequences take priority and significant conflicts between characters are usually resolved with one's physical power. While the overarching plot may involve one group against another, the narrative in action stories is always focused on the strengths/weaknesses of individual characters and the effort they put into their personal battles with the opposing group's members."
                            }
                        },


                        new AnimeGenre()
                        {
                            Anime = new Anime()
                            {
                                Name = "Monster",
                                ReleaseDate = new DateTime(2004, 04, 7),
                                Description = "Dr. Kenzou Tenma, an elite neurosurgeon recently engaged to his hospital director's daughter, is well on his way to ascending the hospital hierarchy. That is until one night, a seemingly small event changes Dr. Tenma's life forever. While preparing to perform surgery on someone, he gets a call from the hospital director telling him to switch patients and instead perform life-saving brain surgery on a famous performer. His fellow doctors, fiancée, and the hospital director applaud his accomplishment; but because of the switch, a poor immigrant worker is dead, causing Dr. Tenma to have a crisis of conscience.",
                                Reviews = new List<Review>()
                                {
                                    new Review
                                    {
                                        Title = "Monster review",
                                        Text = "Monster plays out like a macabre game of cat and mouse in a world that is frighteningly similar to real life. Uncomfortable subjects such as coercive human conditioning and the psychology of the sociopath, morality issues regarding the origin of evil and the value of human life, are horrifyingly, yet engagingly, realized.",
                                        Reviewer = new Reviewer() { FullName = "Walter White", NickName = "wiwi" },
                                        Rating = 8
                                    },
                                    new Review
                                    {
                                        Title = "Monster review",
                                        Text = "If you've heard of Monster, then odds are you've probably heard of the incredible hype surrounding it. For a while, Monster has been the absolute critic's darling of anime, being the poster-boy for lofty intellectual types. Because of this, it can be very easy to imagine Monster as being overhyped.",
                                        Reviewer = new Reviewer() { FullName = "Jesse Pinkman", NickName = "Anime_enjoyer" },
                                        Rating = 10
                                    },
                                    new Review
                                    {
                                        Title = "Monster review",
                                        Text = "Those who have seen Monster can attest collectively (whether they liked it or not) to how incredibly uncomfortable and unconventional this show is. The topic of evil is proactively exploited through revealing the extent of human depravity in conjunction with exploring matters like child abuse, mass murder, collective brainwashing, human experimentation, the value of life, and so much more.",
                                        Reviewer = new Reviewer() { FullName = "Laura Fraser", NickName = "akuma" },
                                        Rating = 10
                                    },

                                },
                                Author = new Author()
                                {
                                    Name = "Naoki Urasawa",
                                    Bio ="Naoki Urasawa is a famous seinen manga artist. Among the most popular works are 20th Century Boys, Master Keaton and Monster. Naoki Urasawa was born on January 2, 1960 in Tokyo and graduated from Meisei University with a degree in economics."

                                },
                                Country = new Country()
                                {
                                    Name = "Japan"
                                }
                            },
                            Genre = new Genre()
                            {
                                Name = "Drama",
                                Description = "Plot-driven stories focused on realistic characters experiencing human struggle. Because drama stories ask the question of what it means to be human, the conflict and emotions will be relatable, even if the settings or characters themselves are not. Here, you will see humanity at its worst, its best, and everything in between."
                            }

                        },


                       new AnimeGenre()
                        {
                            Anime = new Anime()
                            {
                                Name = "JoJo no Kimyou na Bouken Part 5: Ougon no Kaze",
                                ReleaseDate = new DateTime(2018,10,6),
                                Description = "In the coastal city of Naples, corruption is teeming—the police blatantly conspire with outlaws, drugs run rampant around the youth, and the mafia governs the streets with an iron fist. However, various fateful encounters will soon occur.\r\n",
                                Reviews = new List<Review>()
                                {
                                    new Review
                                    {
                                        Title = "JoJo no Kimyou na Bouken Part 5: Ougon no Kaze review",
                                        Text = "As I sat and finished watching the 39-episode saga of Jojo’s Bizarre Adventure: Golden Wind, I had a small tear in my eye. It’s aftermath result of this extraordinary adventure.",
                                        Reviewer = new Reviewer() { FullName = "Anna Gunn", NickName = "anna_gun" },
                                        Rating = 10
                                    },
                                    new Review
                                    {
                                        Title = "JoJo no Kimyou na Bouken Part 5: Ougon no Kaze review",
                                        Text = "This fifth instalment of JoJo tells, of a group of boys in search of justice and a world that, thanks to them and their heroism, will begin to change for the better. Boys who live, sacrifice themselves, fight against an apparently incontrovertible destiny, bringing with them an resolute spirit, a golden wind that blows away the injustices from the world.",
                                        Reviewer = new Reviewer() { FullName = "Marie Schrader", NickName = "nickname" },
                                        Rating = 7
                                    },
                                    new Review
                                    {
                                        Title = "JoJo no Kimyou na Bouken Part 5: Ougon no Kaze review",
                                        Text = "If I could recommend a show that isn't too long but has a great story with characters that go through hell and back for each other while just deliver just an overall great experience I would recommend Golden Wind.",
                                        Reviewer = new Reviewer() { FullName = "Dean Norris", NickName = "narutofun" },
                                        Rating = 9
                                    },

                                },
                                Author = new Author()
                                {
                                    Name = "Araki Hirohiko",
                                    Bio ="Hirohiko Araki is a Japanese mangaka best known for his work on the 8 part JoJo's Bizarre Adventure manga, which has been published in Weekly Shōnen Jump for over 35 years."

                                },
                                Country = new Country()
                                {
                                    Name = "Japan"
                                }
                            },
                            Genre = new Genre()
                            {
                                Name = "Adventure",
                                Description = "Whether aiming for a specific goal or just struggling to survive, the main character is thrust into unfamiliar situations or lands and continuously faces unexpected dangers. The narrative of adventure stories is always on how the characters react to sudden events or trials during the journey, indicating personal growth or setback based on which actions or choices are taken."
                            }
                        }
                    };
                    dataContext.AnimeGenres.AddRange(pokemonOwners);
                    dataContext.SaveChanges();
                }

            }
        }
    }
}
