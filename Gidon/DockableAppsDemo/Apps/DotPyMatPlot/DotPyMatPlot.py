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
        self._main = QtWidgets.QWidget()
        self.setCentralWidget(self._main)
        layout = QtWidgets.QVBoxLayout(self._main)
        layout.setContentsMargins(0,0,0,0)
        canvas = FigureCanvas()
        layout.addWidget(canvas)

        np.random.seed(19680801)  # seed the random number generator.
        data = {'a': np.arange(50),
                'c': np.random.randint(0, 50, 50),
                'd': np.random.randn(50)}
        data['b'] = data['a'] + 10 * np.random.randn(50)
        data['d'] = np.abs(data['d']) * 100

        ax = canvas.figure.subplots()
        ax.scatter('a', 'b', c='c', s='d', data=data)
        ax.set_xlabel('entry a')
        ax.set_ylabel('entry b')

def main(argv):
    sys.path.append(r'../../../Messages/NP.Gidon.PythonMessages')

    import Messages_pb2 as messages

    # Check whether there is already a running QApplication (e.g., if running
    # from an IDE).
    qapp = QtWidgets.QApplication.instance()
    if not qapp:
        qapp = QtWidgets.QApplication(sys.argv)

    app = ApplicationWindow()
    app.show()
    app.activateWindow()
    
    winhandle = int(app.winId())
    print(winhandle);

    if len(argv) > 0:
        app.unique_window_host_id = argv[0];

        broadcastingClient = BroadcastingRelayClient("localhost", 5051)

        broadcastingClient.connect_if_needed()

        winInfo = messages.WindowInfo(WindowHandle=winhandle, UniqueWindowHostId=app.unique_window_host_id)
        broadcastingClient.broadcast_object(winInfo, "WindowInfoTopic", 1)

    app.raise_()
    qapp.exec()

if __name__ == "__main__":
    main(sys.argv[1:])


