﻿using Newtonsoft.Json;

namespace Definux.Utilities.DataAnnotations.Helpers
{
    /// <summary>
    /// Implementation of the class that maps the response from ReCaptcha.
    /// </summary>
    public class ReCaptchaResponse
    {
        /// <summary>
        /// Success status.
        /// </summary>
        [JsonProperty("success")]
        public bool Success { get; set; }

        /// <summary>
        /// ChallengeTs.
        /// </summary>
        [JsonProperty("challenge_ts")]
        public string ChallengeTs { get; set; }

        /// <summary>
        /// Hostname.
        /// </summary>
        [JsonProperty("hostname")]
        public string Hostname { get; set; }

        /// <summary>
        /// Error codes.
        /// </summary>
        [JsonProperty("errorcodes")]
        public string[] ErrorCodes { get; set; }
    }
}