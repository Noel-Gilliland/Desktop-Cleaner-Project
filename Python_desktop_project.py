import os
from win32com.client import Dispatch # type: ignore

onedrive_path = os.path.join(os.path.expanduser("~"), "OneDrive")
desktop_path = os.path.join(onedrive_path, "Desktop")

# Verify if the path exists
if not os.path.exists(desktop_path):
    raise FileNotFoundError(f"Desktop path does not exist: {desktop_path}")

files = [os.path.join(desktop_path, item) for item in os.listdir(desktop_path)]


def get_shortcut_target(shortcut_path):
    """
    Retrieve the target location of a .lnk shortcut file.
    """
    shell = Dispatch("WScript.Shell")
    shortcut = shell.CreateShortcut(shortcut_path)
    return shortcut.TargetPath


i = 0
for file in files:
    if file[-3:] == "lnk":
        target_location = get_shortcut_target(file)
        files[i] = target_location
    i += 1
    
for file in files:
    print(file)
print('\n')

def GrabAllFiles(path: str):
    miscellaneous_checker = [
        [".docx", ".xlsx", ".pptx", ".txt", ".rtf"]
        [".jpg", ".jpeg", ".pdf", ".png", ".bmp", ".gif", ".mp3", ".wav", ".mp4", ".mkv"]
        [".zip", ".rar", ".7z"]
        [".exe", ".lnk", ".bat", ".cmd"]
        [".py", ".html", ".css", ".js", ".json"]
    ]
    filetypes = []
    #Grab Documents
    documents = []
    for file in files:
        if file.endswith(".docx", ".xlsx", ".pptx", ".txt", ".rtf"):
            documents.append(file)
    filetypes.append(documents)
    #Grab Media
    media = []
    for file in files:
        if file.endswith(".jpg", ".jpeg", ".pdf", ".png", ".bmp", ".gif", ".mp3", ".wav", ".mp4", ".mkv"):
            media.append(file)
    filetypes.append(media)
    #Grab Compressed
    compressed = []
    for file in files:
        if file.endswith(".zip", ".rar", ".7z"):
            compressed.append(file)
    filetypes.append(compressed)
    #Grab Exe
    executible = []
    for file in files:
        if file.endswith(".exe", ".lnk", ".bat", ".cmd"): 
            executible.append(file)
    filetypes.append(executible)
    #Grab Development
    development = []
    for file in files:
        if file.endswith(".py", ".html", ".css", ".js", ".json"):
            development.append(file)
    filetypes.append(development)
    #Grab Miscellaneous 
    miscellaneous = []
    for file in files:
        if file not in miscellaneous_checker:
            
            miscellaneous.append(file)
    filetypes.append(miscellaneous)
    
    
