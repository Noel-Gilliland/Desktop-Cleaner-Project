from tkinter import Tk, Frame, BOTH

class Example(Frame):

    def __init__(self, parent):
        Frame.__init__(self, parent, background="white")   

        self.parent = parent        
        self.parent.title('Reminder')
        self.pack(fill=BOTH, expand=1)

def main():

    root = Tk()
    root.geometry("500x500")
    root.resizable(width=False, height=False)
    app = Example(root)
    root.mainloop()  

if __name__ == '__main__':
    main()