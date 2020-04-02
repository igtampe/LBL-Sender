# LBL-Sender
An example of LBL, a one way file transfer protocol for the SmokeSignal Server Framework.
The LBL Extension is available from the ViBE server.
LBL Stands for Line by Line

## How does it work?

To initiate a transfer with the server, ask it to initiate one by sending LBL:OPEN:[Your filename here]

The server replies with an ID to mark your transfer, and then adds it to a list of active transfers.

The server also deletes the local copy of that file.

To send a line, Send LBL:TRANSFER:[ID of transfer]:[Line to transfer] and the Server will append it to the file you specified.

To close off, send LBL:CLOSE:[ID of transfer]. The server should reply with the location of the file on an http server running on the same local machine, so you can later retrieve what you just uploaded.

It's pittifully slow, and should not at all be used for files that are several lines long.
Under my testing over the internet, I found an average rate of 2.7 lines per second.

But for what I need it, IE a file protocol that fits snuggly under the SmokeSignal server, it's more than sufficient.
If you want to use it with your own SmokeSignal server, you're more than welcome to do so.
