import cherrypy
import sqlite3




class Server(object):
    @cherrypy.expose
    def getCommand(self, AppID = -1):
        conn = sqlite3.connect("server.db")
        with conn:
            cur = conn.cursor()
            if(AppID != -1):
                cur.execute("SELECT CommandID FROM apps WHERE Run=0 AND AppID = ?", (AppID))
                val = cur.fetchone()
                if(val != None):
                    cur.execute("UPDATE apps SET Run = 1 WHERE AppID = ?", (AppID))
                    conn.commit()
                    return str(val[0])
                else:
                    return "-1"
            else:
                return "-1"
    @cherrypy.expose
    def setCommand(self, AppID = -1, CommandID = -1):
        conn = sqlite3.connect("server.db")
        with conn:
            cur = conn.cursor()
            cur.execute("UPDATE apps SET CommandID = ?, Run = 0 WHERE AppID = ?", (CommandID, AppID))
            conn.commit()
    @cherrypy.expose
    def getCommands(self):
        conn = sqlite3.connect("server.db")
        with conn:
            cur = conn.cursor()
            cur.execute("SELECT * FROM commands")
            ret = ";".join((str(r[0]) + "," + str(r[1]) for r in cur.fetchall()))
            return ret
            
if __name__ == '__main__':
    conf = {'global':{'server.socket_host':'192.168.35.2','server.socket_port':8080}}
    cherrypy.quickstart(Server(), '/', conf)
