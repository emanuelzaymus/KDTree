namespace GeodeticPDA.Model
{
    interface ICsvSerializable
    {
        /// <summary>
        /// Makes CSV representation from <c>this</c> object.
        /// </summary>
        /// <param name="d">Delimiter</param>
        /// <returns></returns>
        string ToCsv(char d);
    }
}
