#!/bin/sh

pip install --upgrade -r requirements.txt
PYTHONPATH=src:tests python -m pytest