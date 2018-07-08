namespace PodigeeNet.Data
{
    /// <summary>
    /// Represents the podcast category.
    /// </summary>
    public enum PodcastCategory
    {
        /// <summary>
        /// Arts
        /// </summary>
        Arts = 1,

        /// <summary>
        /// Arts - Design
        /// </summary>
        Design = 2,

        /// <summary>
        /// Arts - Fashion &amp; Beauty
        /// </summary>
        FashionBeauty = 3,

        /// <summary>
        /// Arts - Food
        /// </summary>
        Food = 4,

        /// <summary>
        /// Arts - Literature
        /// </summary>
        Literature = 5,

        /// <summary>
        /// Arts - Performing Arts
        /// </summary>
        PerformingArts = 6,

        /// <summary>
        /// Arts - Visual Arts
        /// </summary>
        VisualArts = 7,

        /// <summary>
        /// Business
        /// </summary>
        Business = 8,

        /// <summary>
        /// Business - Business News
        /// </summary>
        BusinessNews = 9,

        /// <summary>
        /// Business - Careers
        /// </summary>
        Careers = 10,

        /// <summary>
        /// Business - Investing
        /// </summary>
        Investing = 11,

        /// <summary>
        /// Business - Management &amp; Marketing
        /// </summary>
        ManagementMarketing = 12,

        /// <summary>
        /// Business - Shopping
        /// </summary>
        Shopping = 13,

        /// <summary>
        /// Comedy
        /// </summary>
        Comedy = 14,

        /// <summary>
        /// Education
        /// </summary>
        Education = 15,

        /// <summary>
        /// Education - Education
        /// </summary>
        EducationEducation = 16,

        /// <summary>
        /// Education - Education Technology
        /// </summary>
        EducationTechnology = 17,

        /// <summary>
        /// Education - Higher Education
        /// </summary>
        HigherEducation = 18,

        /// <summary>
        /// Education - K-12
        /// </summary>
        K12 = 19,

        /// <summary>
        /// Education - Language Courses
        /// </summary>
        LanguageCourses = 20,

        /// <summary>
        /// Education - Training
        /// </summary>
        Training = 21,

        /// <summary>
        /// Games &amp; Hobbies
        /// </summary>
        GamesHobbies = 22,

        /// <summary>
        /// Games &amp; Hobbies - Automotive
        /// </summary>
        Automotive = 23,

        /// <summary>
        /// Games &amp; Hobbies - Aviation
        /// </summary>
        Aviation = 24,

        /// <summary>
        /// Games &amp; Hobbies - Hobbies
        /// </summary>
        Hobbies = 25,

        /// <summary>
        /// Games &amp; Hobbies - Other Games
        /// </summary>
        OtherGames = 26,

        /// <summary>
        /// Games &amp; Hobbies - Video Games
        /// </summary>
        VideoGames = 27,

        /// <summary>
        /// Government &amp; Organizations
        /// </summary>
        GovernmentOrganizations = 28,

        /// <summary>
        /// Government &amp; Organizations - Local
        /// </summary>
        Local = 29,

        /// <summary>
        /// Government &amp; Organizations - National
        /// </summary>
        National = 30,

        /// <summary>
        /// Government &amp; Organizations - Non-Profit
        /// </summary>
        NonProfit = 31,

        /// <summary>
        /// Government &amp; Organizations - Regional
        /// </summary>
        Regional = 32,

        /// <summary>
        /// Health
        /// </summary>
        Health = 33,

        /// <summary>
        /// Health - Alternative Health
        /// </summary>
        AlternativeHealth = 34,

        /// <summary>
        /// Health - Fitness &amp; Nutrition
        /// </summary>
        FitnessNutrition = 35,

        /// <summary>
        /// Health - Self-Help
        /// </summary>
        SelfHelp = 36,

        /// <summary>
        /// Health - Sexuality
        /// </summary>
        Sexuality = 37,

        /// <summary>
        /// Kids &amp; Family
        /// </summary>
        KidsFamily = 38,

        /// <summary>
        /// Music
        /// </summary>
        Music = 39,

        /// <summary>
        /// News &amp; Politics
        /// </summary>
        NewsPolitics = 40,

        /// <summary>
        /// Religion &amp; Spirituality
        /// </summary>
        ReligionSpirituality = 41,

        /// <summary>
        /// Religion &amp; Spirituality - Buddhism
        /// </summary>
        Buddhism = 42,

        /// <summary>
        /// Religion &amp; Spirituality - Christianity
        /// </summary>
        Christianity = 43,

        /// <summary>
        /// Religion &amp; Spirituality - Hinduism
        /// </summary>
        Hinduism = 44,

        /// <summary>
        /// Religion &amp; Spirituality - Islam
        /// </summary>
        Islam = 45,

        /// <summary>
        /// Religion &amp; Spirituality - Judaism
        /// </summary>
        Judaism = 46,

        /// <summary>
        /// Religion &amp; Spirituality - Other
        /// </summary>
        Other = 47,

        /// <summary>
        /// Religion &amp; Spirituality - Spirituality
        /// </summary>
        Spirituality = 48,

        /// <summary>
        /// Science &amp; Medicine
        /// </summary>
        ScienceMedicine = 49,

        /// <summary>
        /// Science &amp; Medicine - Medicine
        /// </summary>
        Medicine = 50,

        /// <summary>
        /// Science &amp; Medicine - Natural Sciences
        /// </summary>
        NaturalSciences = 51,

        /// <summary>
        /// Science &amp; Medicine - Social Sciences
        /// </summary>
        SocialSciences = 52,

        /// <summary>
        /// Society &amp; Culture
        /// </summary>
        SocietyCulture = 53,

        /// <summary>
        /// Society &amp; Culture - History
        /// </summary>
        History = 54,

        /// <summary>
        /// Society &amp; Culture - Personal Journals
        /// </summary>
        PersonalJournals = 55,

        /// <summary>
        /// Society &amp; Culture - Philosophy
        /// </summary>
        Philosophy = 56,

        /// <summary>
        /// Society &amp; Culture - Places &amp; Travel
        /// </summary>
        PlacesTravel = 57,

        /// <summary>
        /// Sports &amp; Recreation
        /// </summary>
        SportsRecreation = 58,

        /// <summary>
        /// Sports &amp; Recreation - Amateur
        /// </summary>
        Amateur = 59,

        /// <summary>
        /// Sports &amp; Recreation - College &amp; High School
        /// </summary>
        CollegeHighSchool = 60,

        /// <summary>
        /// Sports &amp; Recreation - Outdoor
        /// </summary>
        Outdoor = 61,

        /// <summary>
        /// Sports &amp; Recreation - Professional
        /// </summary>
        Professional = 62,

        /// <summary>
        /// Technology
        /// </summary>
        Technology = 63,

        /// <summary>
        /// Technology - Gadgets
        /// </summary>
        Gadgets = 64,

        /// <summary>
        /// Technology - Tech News
        /// </summary>
        TechNews = 65,

        /// <summary>
        /// Technology - Podcasting
        /// </summary>
        Podcasting = 66,

        /// <summary>
        /// Technology - Software How-To
        /// </summary>
        SoftwareHowTo = 67,

        /// <summary>
        /// TV &amp; Film
        /// </summary>
        TvFilm = 68
    }
}