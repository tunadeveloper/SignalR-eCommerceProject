// Chart js

var theme = {
  primary: 'var(--ds-primary)',
  secondary: 'var(--ds-secondary)',
  success: 'var(--ds-success)',
  info: 'var(--ds-info)',
  warning: 'var(--ds-warning)',
  danger: 'var(--ds-danger)',
  dark: 'var(--ds-dark)',
  light: 'var(--ds-light)',
  white: 'var(--ds-white)',
  infoDark: '#006C9C',
  successLight: '#77ED8B',
  gray100: 'var(--ds-gray-100)',
  gray200: 'var(--ds-gray-200)',
  gray300: 'var(--ds-gray-300)',
  gray400: 'var(--ds-gray-400)',
  gray500: 'var(--ds-gray-500)',
  gray600: 'var(--ds-gray-600)',
  gray700: 'var(--ds-gray-700)',
  gray800: 'var(--ds-gray-800)',
  gray900: 'var(--ds-gray-900)',
  black: 'var(--ds-black)',
  transparent: 'transparent',
};

// Add theme to the window object
window.theme = theme;

(function () {
  // Perfomance Chart

  if (document.getElementById('totalIncomeChart')) {
    var options = {
      series: [
        {
          name: 'Total Income',
          data: [31, 40, 28, 51, 42, 109, 100],
        },
      ],
      labels: ['Jan', 'Feb', 'March', 'April', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
      chart: {
        height: 350,
        type: 'area',
        toolbar: {
          show: false,
        },
        fontFamily: 'Public Sans, serif',
      },
      dataLabels: {
        enabled: false,
      },
      markers: {
        size: 5,
        hover: {
          size: 6,
          sizeOffset: 3,
        },
      },
      colors: ['#00a76f'],
      stroke: {
        curve: 'smooth',
        width: 2,
      },
      grid: {
        show: true,
        borderColor: window.theme.gray300,
        strokeDashArray: 2,
      },
      xaxis: {
        labels: {
          show: true,
          align: 'right',
          minWidth: 0,
          maxWidth: 160,
          style: {
            fontSize: '12px',
            fontWeight: 400,
            colors: [window.theme.gray600],
            fontFamily: 'Public Sans, serif',
          },
        },
        axisBorder: {
          show: false,
          color: window.theme.gray300,
          height: 1,
          width: '100%',
          offsetX: 0,
          offsetY: 0,
        },
        axisTicks: {
          show: false,
          borderType: 'solid',
          color: window.theme.gray300,
          height: 6,
          offsetX: 0,
          offsetY: 0,
        },
      },
      legend: {
        show: false, // Disable built-in legend
      },
      yaxis: {
        labels: {
          formatter: function (e) {
            return e + 'k';
          },

          show: true,
          align: 'right',
          minWidth: 0,
          maxWidth: 160,
          style: {
            fontSize: '12px',
            fontWeight: 400,
            colors: window.theme.gray600,
            fontFamily: 'Public Sans, serif',
          },
        },
      },
    };
    var chart = new ApexCharts(document.querySelector('#totalIncomeChart'), options);
    chart.render();
  }

  if (document.getElementById('totalExpensesChart')) {
    var options = {
      series: [
        {
          name: 'Total Expenses',
          data: [11, 32, 45, 32, 34, 52, 41],
        },
      ],
      labels: ['Jan', 'Feb', 'March', 'April', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
      chart: {
        height: 350,
        type: 'area',
        toolbar: {
          show: false,
        },
        fontFamily: 'Public Sans, serif',
      },
      grid: {
        show: true,
        borderColor: window.theme.gray300,
        strokeDashArray: 2,
      },
      dataLabels: {
        enabled: false,
      },
      markers: {
        size: 5,
        hover: {
          size: 6,
          sizeOffset: 3,
        },
      },
      colors: [window.theme.warning],
      stroke: {
        curve: 'smooth',
        width: 2,
      },

      xaxis: {
        labels: {
          show: true,
          align: 'right',
          minWidth: 0,
          maxWidth: 160,
          style: {
            fontSize: '12px',
            fontWeight: 400,
            colors: [window.theme.gray600],
            fontFamily: 'Public Sans, serif',
          },
        },
        axisBorder: {
          show: false,
          color: window.theme.gray300,
          height: 1,
          width: '100%',
          offsetX: 0,
          offsetY: 0,
        },
        axisTicks: {
          show: false,
          borderType: 'solid',
          color: window.theme.gray300,
          height: 6,
          offsetX: 0,
          offsetY: 0,
        },
      },
      legend: {
        show: false, // Disable built-in legend
      },
      yaxis: {
        labels: {
          formatter: function (e) {
            return e + 'k';
          },
          show: true,
          align: 'right',
          minWidth: 0,
          maxWidth: 160,
          style: {
            fontSize: '12px',
            fontWeight: 400,
            colors: window.theme.gray600,
            fontFamily: 'Public Sans, serif',
          },
        },
      },
    };
    var chart = new ApexCharts(document.querySelector('#totalExpensesChart'), options);
    chart.render();
  }

  // total sale donut chart
  if (document.getElementById('totalSale')) {
    var options = {
      series: [40, 30, 25, 10],
      labels: ['Smartphones', 'Laptops', 'Headphones', 'Cameras'],
      colors: [window.theme.primary, window.theme.warning, window.theme.info, window.theme.danger],
      chart: {
        type: 'donut',
        height: 377,
        fontFamily: 'Public Sans, serif',
      },
      legend: {
        show: false,
      },
      dataLabels: {
        enabled: true,
        dropShadow: {
          blur: 0,
          opacity: 0,
        },
      },
      plotOptions: {
        pie: {
          donut: {
            size: '65%',
          },
        },
      },
      stroke: {
        width: 0,
      },
      responsive: [
        {
          breakpoint: 1400,
          options: {
            chart: {
              type: 'donut',
              width: 290,
              height: 330,
            },
          },
        },
      ],
    };

    var chart = new ApexCharts(document.querySelector('#totalSale'), options);
    chart.render();
  }

  if (document.getElementById('salesBygender')) {
    var options = {
      series: [44, 55, 67],
      chart: {
        height: 350,
        type: 'radialBar',
      },
      colors: ['#5BE49B', '#FFF5CC', '#FFE9D5'],
      plotOptions: {
        radialBar: {
          dataLabels: {
            name: {
              fontSize: '22px',
            },
            value: {
              fontSize: '16px',
            },
            total: {
              show: false,
            },
          },
          hollow: {
            margin: 3,
            size: '40%',
            background: 'transparent',
            image: undefined,
            imageWidth: 150,
            imageHeight: 150,
            imageOffsetX: 0,
            imageOffsetY: 0,
            imageClipped: true,
            position: 'front',
            dropShadow: {
              enabled: false,
              top: 0,
              left: 0,
              blur: 3,
              opacity: 0.5,
            },
          },
          track: {
            show: true,
            startAngle: undefined,
            endAngle: undefined,
            background: window.theme.gray300,
            strokeWidth: '45%',
            opacity: 1,
            margin: 5,
            dropShadow: {
              enabled: false,
              top: 0,
              left: 0,
              blur: 3,
              opacity: 0.5,
            },
          },
        },
      },
      fill: {
        type: 'gradient',
        gradient: {
          shade: 'dark',
          type: 'vertical',
          gradientToColors: ['#007867', '#FFD666', '#FFAC82'],
          stops: [0, 100],
        },
      },
      stroke: {
        lineCap: 'round',
      },

      labels: ['Men', 'Womens', 'Kids'],
    };

    var chart = new ApexCharts(document.querySelector('#salesBygender'), options);
    chart.render();
  }

  // location map
  if (document.getElementById('map-world')) {
    const map = new jsVectorMap({
      selector: '#map-world',
      map: 'world',
      backgroundColor: 'transparent',
      regionStyle: {
        initial: {
          fill: window.theme.gray300,
          stroke: window.theme.gray300,
          strokeWidth: 2,
        },
      },
      zoomOnScroll: false,
      zoomButtons: false,
      // -------- Series --------
      visualizeData: {
        scale: ['#fcfdfd', '#c4cdd5', '#ff0000'], // Define a color scale
        values: {
          AF: 16,
          AL: 11,
          DZ: 158,
          AO: 85,
          AG: 1,
          AR: 351,
          AM: 8,
          AU: 1219,
          AT: 366,
          AZ: 52,
          BS: 7,
          BH: 21,
          BD: 105,
          BB: 3,
          BY: 52,
          BE: 461,
          BZ: 1,
          BJ: 6,
          BT: 1,
          BO: 19,
          BA: 16,
          BW: 12,
          BR: 2023,
          BN: 11,
          BG: 44,
          BF: 8,
          BI: 1,
          KH: 11,
          CM: 21,
          CA: 1563,
          CV: 1,
          CF: 2,
          TD: 7,
          CL: 199,
          CN: 5745,
          CO: 283,
          KM: 0,
          CD: 12,
          CG: 11,
          CR: 35,
          CI: 22,
          HR: 59,
          CY: 22,
          CZ: 195,
          DK: 304,
          DJ: 1,
          DM: 0,
          DO: 50,
          EC: 61,
          EG: 216,
          SV: 21,
          GQ: 14,
          ER: 2,
          EE: 19,
          ET: 30,
          FJ: 3,
          FI: 231,
          FR: 2555,
          GA: 12,
          GM: 1,
          GE: 11,
          DE: 3305,
          GH: 18,
          GR: 305,
          GD: 0,
          GT: 40,
          GN: 4,
          GW: 0,
          GY: 2,
          HT: 6,
          HN: 15,
          HK: 226,
          HU: 132,
          IS: 12,
          IN: 10000,
          ID: 695,
          IR: 337,
          IQ: 84,
          IE: 204,
          IL: 201,
          IT: 2036,
          JM: 13,
          JP: 5390,
          JO: 27,
          KZ: 129,
          KE: 32,
          KI: 0,
          KR: 986,
          KW: 117,
          KG: 4,
          LA: 6,
          LV: 23,
          LB: 39,
          LS: 1,
          LR: 0,
          LY: 77,
          LT: 35,
          LU: 52,
          MK: 9,
          MG: 8,
          MW: 5,
          MY: 218,
          MV: 1,
          ML: 9,
          MT: 7,
          MR: 3,
          MU: 9,
          MX: 1004,
          MD: 5,
          MN: 5,
          ME: 3,
          MA: 91,
          MZ: 10,
          MM: 35,
          NA: 11,
          NP: 15,
          NL: 770,
          NZ: 138,
          NI: 6,
          NE: 5,
          NG: 206,
          NO: 413,
          OM: 53,
          PK: 174,
          PA: 27,
          PG: 8,
          PY: 17,
          PE: 153,
          PH: 189,
          PL: 438,
          PT: 223,
          QA: 126,
          RO: 158,
          RU: 1476,
          RW: 5,
          WS: 0,
          ST: 0,
          SA: 434,
          SN: 12,
          RS: 38,
          SC: 0,
          SL: 1,
          SG: 217,
          SK: 86,
          SI: 46,
          SB: 0,
          ZA: 354,
          ES: 1374,
          LK: 48,
          KN: 0,
          LC: 1,
          VC: 0,
          SD: 65,
          SR: 3,
          SZ: 3,
          SE: 444,
          CH: 522,
          SY: 59,
          TW: 426,
          TJ: 5,
          TZ: 22,
          TH: 312,
          TL: 0,
          TG: 3,
          TO: 0,
          TT: 21,
          TN: 43,
          TR: 729,
          TM: 0,
          UG: 17,
          UA: 136,
          AE: 239,
          GB: 2258,
          US: 4624,
          UY: 40,
          UZ: 37,
          VU: 0,
          VE: 285,
          VN: 101,
          YE: 30,
          ZM: 15,
          ZW: 5,
        },
      },
    });
    window.addEventListener('resize', () => {
      map.updateSize();
    });
  }


})();
