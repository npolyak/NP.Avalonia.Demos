from ctypes import alignment
import sys
import time
from tkinter import TOP

import numpy as np

from matplotlib.backends.qt_compat import QtWidgets
from matplotlib.backends.backend_qtagg import FigureCanvas
from matplotlib.figure import Figure
from BroadcastingRelayClient import BroadcastingRelayClient
import sys;

class ApplicationWindow(QtWidgets.QMainWindow):
    def __init__(self):
        super().__init__()
        # create QWidget, its layout and canvas for the figure
        self._main = QtWidgets.QWidget()
        self.setCentralWidget(self._main)
        layout = QtWidgets.QVBoxLayout(self._main)
        layout.setContentsMargins(0,0,0,0)
        canvas = FigureCanvas()
        layout.addWidget(canvas)

        # generate data for the plot
        np.random.seed(19680801) 
        data = {'a': np.arange(50),
                'c': np.random.randint(0, 50, 50),
                'd': np.random.randn(50)}
        data['b'] = data['a'] + 10 * np.random.randn(50)
        data['d'] = np.abs(data['d']) * 100
        #end generate data for the plot

        # create plot
        plt = canvas.figure.subplots()
        #paint the dots 
        plt.scatter('a', 'b', c='c', s='d', data=data)

        #set the names of the axes of the plot
        plt.set_xlabel('entry a')
        plt.set_ylabel('entry b')

def main(argv):
    sys.path.append(r'..\CommonPython\env\Lib\site-packages')

    import Messages_pb2 as messages

    # Check whether there is already a running QApplication (e.g., if running
    # from an IDE).
    qapp = QtWidgets.QApplication.instance()
    if not qapp:
        qapp = QtWidgets.QApplication(sys.argv)

    #create and show the window
    app = ApplicationWindow()
    app.show()
    app.activateWindow()
    
    # get the handle of the window
    winhandle = int(app.winId())
    print(winhandle);

    # argument means that the Python program is started from the C# code
    if len(argv) > 0:
        app.unique_window_host_id = argv[0]; #unique window host id

        #create Relay Client
        broadcastingClient = BroadcastingRelayClient("localhost", 5051)

        # connect the relay client to the server
        broadcastingClient.connect_if_needed()

        # create the WindowInfo object containing the UniqueWindowHostId and the WindowHandle
        winInfo = messages.WindowInfo(WindowHandle=winhandle, UniqueWindowHostId=app.unique_window_host_id)

        #publish the WindowInfo object to the Relay Server
        broadcastingClient.broadcast_object(winInfo, "WindowInfoTopic", 1)

    app.raise_()
    qapp.exec()

if __name__ == "__main__":
    main(sys.argv[1:])


