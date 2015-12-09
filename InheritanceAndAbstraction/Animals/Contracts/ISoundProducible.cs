namespace Animals.Contracts
{
    public interface ISoundProducible
    {
        /// <summary>
        /// By returning a string instead of writing on the console, the classes implementing
        /// tihs interface, don't couple themselves to the Console, the user is free to
        /// deside if he wan't to print, save the result or use the result in other ways
        /// </summary>
        /// <returns></returns>
        string ProduceSound();
    }
}