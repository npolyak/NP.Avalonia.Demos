import sys
import time

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

        canvas = FigureCanvas(Figure(figsize=(5, 3)))
        layout.addWidget(canvas)

        self._ax = canvas.figure.subplots()

        t = np.linspace(0, 10, 101)

        #set up a line2d
        self._line, = self._ax.plot(t, np.sin(t + time.time()))

def main(argv):
    sys.path.append(r'..\CommonPython\common_env\Lib\site-packages')

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

    winInfo = messages.WindowInfo()

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


