using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using VkNet;
using VkNet.Enums.Filters;

namespace AudioPlayer
{
    public class VkAudio
    {
        /*
         * NuGet:
         * VkNet
         */
        private VkApi vkApi;
        private ulong _appId = 7796318;
        private string _email;
        private string _pass;
        private Settings _settings;

        public VkAudio(string email, string password)
        {
            // vkApi = new VkApi();
            _email = email;
            _pass = password;
            _settings = Settings.Audio;
            
            // vkApi.Authorize(
            //     ApiAuthParams.Format(
            //     appId: (ulong) _appId,
            //     login: _email,
            //     password: _pass,
            //     settings: _settings
            // ));
            
            //TODO: VK Auth via Browser
            vkApi.AuthorizationFlow.AuthorizeAsync();
            // vkApi.Authorize(new ApiAuthParams()
            // {
            //     ApplicationId = _appId,
            //     Login = _email,
            //     Password = _pass,
            //     Settings = _settings
            // });
        }

        public void test()
        {
            
        }
    }
}