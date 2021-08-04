import requests
from bs4 import BeautifulSoup

class calculator:
    def getlink(url):
        reqs = requests.get(url)
        soup = BeautifulSoup(reqs.text, 'html.parser')
        lst = []
        urls = []
        for link in soup.find_all('a'):
            # print(link.get('href'))
            # yield map(str(int), link.get('href'))
            lst.append(link.get('href'))
        return lst


    def add(self, x, y):
        return x + y


