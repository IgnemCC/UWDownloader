# UWDownloader
A simple Download Tool for Lectures/Videos of the University of Vienna (hosted by univie.ac.at) using ffmpeg to merge audio and video streams.

## Manual for UWDownloader (updated 16.10.2020)
Github: https://github.com/IgnemCC/UWDownloader

A small tool to efficiently and automatically download Lectures from BigBlueButton, hosted by univie.ac.at,
using ffmpeg by https://ffmpeg.org

To download a single link, simply paste the link into the program and enter the desired file name.
The file name can't contain any spaces as this leads to errors while converting with ffmpeg

To download multiple files, simply paste the links to each lecture into the links.txt file
(One Link per Line)
The output is then saved as "Vorlesung" + line number of the link, e.G. "Vorlesung1".

## Installation

Download from https://github.com/IgnemCC/UWDownloader/releases/download/v1.0/UWDownloader.zip
Run the dotnet-runtime installer if dotnet is not already present on your computer
Run the application

## Trouble Shooting

If the app doesn't load, make sure you have .net Core Runtime installed
(downloadable from Microsoft: https://dotnet.microsoft.com/download/dotnet-core)
If downloading fails, make sure you provided a working link.
If converting fails, make sure the ffmpeg.exe is present - if not, download it from https://ffmpeg.org
Make sure file names don't contain any spaces.
