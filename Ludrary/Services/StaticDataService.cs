using Ludrary.Models;

namespace Ludrary.Services
{
    public class StaticDataService
    {
        public List<Tag> GameplayTags { get; } = new List<Tag>
{
    // Oynanış Tarzı
    new Tag { Id = 7, Name = "Multiplayer" },
new Tag { Id = 31, Name = "Singleplayer" },
new Tag { Id = 36, Name = "Open World" },
new Tag { Id = 30, Name = "FPS" },
new Tag { Id = 18, Name = "Co-op" },
new Tag { Id = 69, Name = "Action-Adventure" },
new Tag { Id = 24, Name = "RPG" },
new Tag { Id = 8, Name = "First-Person" },
new Tag { Id = 150, Name = "Third-Person Shooter" },
new Tag { Id = 17, Name = "Survival Horror" },
new Tag { Id = 125, Name = "Crafting" },
new Tag { Id = 39, Name = "Building" },
new Tag { Id = 37, Name = "Sandbox" },
new Tag { Id = 121, Name = "Character Customization" },
new Tag { Id = 11, Name = "Team-Based" },
new Tag { Id = 97, Name = "Action RPG" },
new Tag { Id = 6, Name = "Exploration" },
new Tag { Id = 131, Name = "Fast-Paced" },
new Tag { Id = 80, Name = "Tactical" },
new Tag { Id = 149, Name = "Third Person" },
new Tag { Id = 68, Name = "Hack and Slash" },
new Tag { Id = 49, Name = "Difficult" },
new Tag { Id = 639, Name = "Roguelike" },
new Tag { Id = 102, Name = "Turn-Based" },
new Tag { Id = 157, Name = "PvP" },
new Tag { Id = 101, Name = "Turn-Based Strategy" },
new Tag { Id = 15, Name = "Stealth" },
new Tag { Id = 168, Name = "RTS" },
new Tag { Id = 141, Name = "Point & Click" }
};

public List<Tag> ThemeTags { get; } = new List<Tag>
{
    // Atmosfer & Hikaye
    new Tag { Id = 13, Name = "Atmospheric" },
    new Tag { Id = 118, Name = "Story Rich" },
    new Tag { Id = 145, Name = "Choices Matter" },
    new Tag { Id = 110, Name = "Cinematic" },
    new Tag { Id = 117, Name = "Mystery" },
    new Tag { Id = 32, Name = "Sci-fi" },
    new Tag { Id = 167, Name = "Futuristic" },
    new Tag { Id = 25, Name = "Space" },
    new Tag { Id = 172, Name = "Aliens" },
    new Tag { Id = 64, Name = "Fantasy" },
    new Tag { Id = 40, Name = "Dark Fantasy" },
    new Tag { Id = 66, Name = "Medieval" },
    new Tag { Id = 82, Name = "Magic" },
    new Tag { Id = 16, Name = "Horror" },
    new Tag { Id = 17, Name = "Survival Horror" }, 
    new Tag { Id = 43, Name = "Post-apocalyptic" },
    new Tag { Id = 63, Name = "Zombies" },
    new Tag { Id = 70, Name = "War" },
    new Tag { Id = 89, Name = "Historical" },
    new Tag { Id = 41, Name = "Dark" },
    new Tag { Id = 4, Name = "Funny" },
    new Tag { Id = 123, Name = "Comedy" },
    new Tag { Id = 192, Name = "Mature" },
    new Tag { Id = 26, Name = "Gore" },
    new Tag { Id = 34, Name = "Violent" },
    new Tag { Id = 189, Name = "Female Protagonist" }
};

public List<Tag> StyleTags { get; } = new List<Tag>
{
    new Tag { Id = 571, Name = "3D" },
    new Tag { Id = 79, Name = "Free to Play" },
    new Tag { Id = 45, Name = "2D" },
    new Tag { Id = 134, Name = "Anime" },
    new Tag { Id = 77, Name = "Realistic" },
    new Tag { Id = 165, Name = "Colorful" },
    new Tag { Id = 122, Name = "Pixel Graphics" },
    new Tag { Id = 99, Name = "Isometric" },
    new Tag { Id = 113, Name = "Side Scroller" },
    new Tag { Id = 88, Name = "Cute" },
    new Tag { Id = 74, Name = "Retro" },
    new Tag { Id = 193, Name = "Classic" }
};


        public List<Tag> AllTags { get; }
        private readonly HashSet<int> _selectedTagIds;
        public StaticDataService()
        {
            AllTags = new List<Tag>();
            AllTags.AddRange(GameplayTags);
            AllTags.AddRange(ThemeTags);
            AllTags.AddRange(StyleTags);

            _selectedTagIds = new HashSet<int>(AllTags.Select(t => t.Id));
        }

        public bool IsTagSelected(int tagId)
        {
            return _selectedTagIds.Contains(tagId);
        }
    }
}
