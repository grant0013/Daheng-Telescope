Daheng Telescope Control - Project Summary & Features
This document outlines the features and changes implemented in the Daheng Telescope Control application. The project has evolved from a basic camera viewer into a capable astrophotography capture tool.

Core Functionality
Camera Connection: The application automatically detects and connects to the first available Daheng Imaging camera using the GxIAPINET SDK.

Live Video Stream: Provides a real-time video feed from the connected camera.

Start/Stop/Record: Full control over starting and stopping the video stream, as well as recording video sequences.

Astrophotography & Capture Features
Manual Exposure & Gain: Full manual control over exposure time and gain, which is essential for astrophotography.

Exposure is set in seconds for intuitive, DSLR-like operation.

Gain is set as a direct multiplier.

Input values are automatically validated and clamped to the camera's supported range.

RAW Image Capture: A dedicated button allows for capturing a single, unprocessed raw frame (.raw file) for maximum quality in post-processing.

Video Sequence Recording: The "Record" button saves a sequence of frames as individual BMP images to a timestamped folder. This is the ideal format for stacking software like AutoStakkert! and RegiStax.

Custom Save Location: Users can select a custom folder to save all captured raw images and video recordings.

Advanced Camera & Image Controls
Auto Exposure & Auto Gain: Buttons to toggle the camera's automatic exposure and gain modes. When active, the manual textboxes become read-only and display the live values from the camera.

Auto White Balance: A button to toggle the camera's automatic white balance, useful for setting a baseline color correction.

Full Resolution Control:

Pixel Format: A dropdown allows selection of the camera's native sensor format (e.g., BayerRG8, Mono12) for uncompressed data capture.

Binning: A dropdown allows control over pixel binning (e.g., 1x1 for full resolution, 2x2 for increased sensitivity).

Live View Enhancement: To aid in focusing and framing faint deep-sky objects, the application includes a suite of real-time image processing controls that only affect the live display, not the saved raw data:

Gamma, Contrast, Brightness: Sliders to stretch the histogram of the live view.

Manual Color Balance: Red, Green, and Blue sliders provide precise control to neutralize color casts, especially useful for cameras with their IR cut filter removed.

User Interface
Tabbed Layout: All camera controls are organized into a clean, multi-tabbed interface to ensure the UI is easy to navigate and fits comfortably on the screen. The tabs are logically grouped into:

Camera: Core settings like Exposure, Gain, White Balance, Pixel Format, and Binning.

Live View: Real-time display adjustments like Gamma, Contrast, Brightness, and Color Balance.

Capture & Saving: Controls for recording video, capturing raw images, and selecting the save location.

Real-time Feedback: The UI provides constant feedback, such as changing button colors to indicate active states (e.g., "Record" turns red) and updating labels with live data from the camera.
