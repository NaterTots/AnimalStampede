using System;

//i don't like this....we should find a way to scope them in a way that IDs wont overlap
static class Events
{
    public static class Game
    {
        public static int ScoredPoints = 1;

    }

    public static class Framework
    {
        public static int StatChanged = 11;
    }


    /*
    public static class Dodge
    {
        public static int BadCollectible = 1;
        public static int GoodCollectible = 2;
    }

    public static class Shoot
    {
        public static int BaddieKilled = 3;
        public static int PlayerBaseDestroyed = 4;
    }
    */
    public static class GameStateTransition
    {
        public static int TransitionAway = 21;
        public static int TransitionTo = 22;
    }

    public static class PlayingStateTransition
    {
        public static int TransitionAway = 31;
        public static int TransitionTo = 32;
    }

    public static class Level
    {
        public static int LostLevel = 41;
        public static int WonLevel = 42;
        public static int AnimalPassedThreshold = 43;
        public static int TimelineComplete = 44;
    }

    public static class Story
    {
        public static int CompleteStory = 51;
    }

    public static class Pause
    {
        public static int UnPause = 61;
    }

    public static class Retry
    {
        public static int RetryLevel = 71;
        public static int ReturnToMainMenu = 72;
    }
}

