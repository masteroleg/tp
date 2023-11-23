namespace TraceavitProDesktop.backApi.barScan;

//using Windows.Devices.PointOfService;

/*
    private async void InitScaner()
    {
        try
        {
            await CreateDefaultScannerObject();
            if (scanner != null)
            {
                claimedScanner = await scanner.ClaimScannerAsync();

                if (claimedScanner != null)
                {
                    claimedScanner.DataReceived += claimedScanner_DataReceived;
                    claimedScanner.IsDecodeDataEnabled = true;
                    await claimedScanner.EnableAsync();
                }
            }
        }
        catch
        {
            try
            {
                if (claimedScanner != null)
                {
                    claimedScanner.IsDecodeDataEnabled = true;
                    claimedScanner.Dispose();
                    claimedScanner = null;
                }

                if (scanner != null)
                {
                    scanner.Dispose();
                    scanner = null;
                }
            }
            catch
            {

            }
        }
    }
    
    private async Task<bool> CreateDefaultScannerObject()
    {
        if (scanner == null)
        {
            scanner = await BarcodeScanner.GetDefaultAsync();

            if (scanner != null)
            {
                //    Logging.TrackEvent(TrackName.ScannerConnected, "Device Id is:" + scanner.DeviceId);
            }
            else
            {
               // Logging.TrackEvent(TrackName.ScannerConnectError, "Barcode Scanner not found. Please connect a Barcode Scanner.");
               // await Dispatcher.RunAsync(
               //     CoreDispatcherPriority.Normal,
               //     () =>
               //     {
               //         ShowMsg(AppGlobal.GetResourceStr(ResourcesKey.ContentDialogTitleError.ToString()),
               //                 AppGlobal.GetResourceStr(ResourcesKey.ScannerNotFound.ToString()));
               //     });
                return false;
            }
        }

        return true;
    }

    async void claimedScanner_DataReceived(ClaimedBarcodeScanner sender, BarcodeScannerDataReceivedEventArgs args)
    {
        try
        {
            var scan = string.Empty;
            string label = CryptographicBuffer.EncodeToHexString(args.Report.ScanDataLabel);
            
            //byte[] bytes = AppGlobal.StringToByteArray(label);
            byte[] bytes = Encoding.ASCII.GetBytes(label); ;
            
            scan = Encoding.UTF8.GetString(bytes);
            
            //Logging.TrackEvent(TrackName.ScannerLabel, scan);

        }
        catch (Exception ex)
        {
            //Logging.TrackError(ex, TrackName.Exeption);
        }

       // await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
       // {
       //     try
       //     {
       //         btnDelete_Click(null, null);
       //         if (AppGlobal.IsJson(scan))
       //         {
       //             taskScan = JsonConvert.DeserializeObject<TaskScan>(scan);
       //             ShowData();
       //             tbInput.Focus(FocusState.Keyboard);
       //         }
       //         else
       //             ShowMsg(AppGlobal.GetResourceStr(ResourcesKey.ContentDialogTitleError.ToString()),
       //                     AppGlobal.GetResourceStr(ResourcesKey.FormatDataError.ToString()));
       //     }
       //     catch (Exception ex)
       //     {
       //         Logging.TrackError(ex, TrackName.Exeption);
       //     }
       // });

    }

    */