//Wrapper implementation for 3rd party tool
using System;
using ThirdPartyTools;

namespace FileData
{
    /// <summary>
    /// FileDetails 3rd party tools wrapper. Provides functionality to identify the version and size of a particular file.
    /// </summary>
    public class FileDetailsExtended : IWrapper
    {
        //3rd party tools
        FileDetails _fileDetails;

        public FileDetailsExtended()
        {
            //the 3rd party tool implementation
            _fileDetails = new FileDetails();
        }

        /// <summary>
        /// Performs the required action; Version or Size.
        /// </summary>
        /// <param name="actionParameter">Parameter will dictate which action to perform</param>
        /// <param name="filename">dummy filename</param>
        /// <returns></returns>
        public T Action<T>(string actionParameter, string filename)
        {
            T actionResult;

            switch(actionParameter)
            {
                //Version action
                case "-v":
                case "--v":
                case "/v":
                case "--version":
                    actionResult = (T) Convert.ChangeType(_fileDetails.Version(filename), typeof(T));
                    break;

                //Size action
                case "-s":
                case "--s":
                case "/s":
                case "--size":
                    actionResult = (T)Convert.ChangeType(_fileDetails.Size(filename), typeof(T));
                    break;

                default:
                    actionResult = default(T);//explicitally set the action to error state
                    break;
            }

            return actionResult;
        }
    }
}
