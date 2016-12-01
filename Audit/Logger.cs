using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using Audit.Exceptions;
using Audit.Interfaces;
using Audit.Model;

namespace Audit
{
    public class Logger
    {
        private readonly string _applicationName;
        private readonly ILoggerStorage _storage;
        private bool _enabled;

        private readonly Queue<Client> _logQueue;

        private const string AUDIT_ENABLED = "Audit.Enabled";
        private const string LOOP_TIME_IN_MILLISECONDS_SETTING = "Audit.LoopTimeInMilliseconds";

        private Logger(string applicationName, Settings settings, ILoggerStorage storage)
        {
            LoggerSettings = settings ?? new Settings();

            _enabled = LoggerSettings.Enabled;
            _applicationName = applicationName;
            _storage = storage;
            _logQueue = new Queue<Client>();

            var loggingBackgroundWorker = new Thread(Start)
            {
                IsBackground = true
            };
            loggingBackgroundWorker.Start();
        }

        public Settings LoggerSettings { get; }

        public static Logger Start(string applicationName)
        {
            var enabledSetting = ConfigurationManager.AppSettings[AUDIT_ENABLED];

            // Mandatory settings

            bool enabled;
            if (enabledSetting == null || !bool.TryParse(enabledSetting, out enabled))
            {
                throw new LoggerSetupException($"AppSetting {AUDIT_ENABLED} is not defined correctly.");
            }

            Settings settings = new Settings
            {
                Enabled = enabled
            };

            // Optional settings

            var loopTimeInMilliSecondsSetting = ConfigurationManager.AppSettings[LOOP_TIME_IN_MILLISECONDS_SETTING];

            int loopTimeInMilliseconds;
            if (loopTimeInMilliSecondsSetting != null &&
                int.TryParse(loopTimeInMilliSecondsSetting, out loopTimeInMilliseconds))
            {
                settings.LoopTimeInMilliseconds = (settings.LoopTimeInMilliseconds < loopTimeInMilliseconds)
                    ? loopTimeInMilliseconds
                    : settings.LoopTimeInMilliseconds;
            }

            // Creating storage
            ILoggerStorage storage = null;

            return new Logger(applicationName, settings, storage);
        }

        private void Start()
        {
            InitializeStorage();

            while (_enabled)
            {
                Thread.Sleep(LoggerSettings.LoopTimeInMilliseconds);

                // TODO: Process entries in logging queue

            }
        }

        private void InitializeStorage()
        {
            // TODO: until storage initialization is implemented, _enabled is set to false so logging is not started.
            _enabled = false;
        }     
    }
}
